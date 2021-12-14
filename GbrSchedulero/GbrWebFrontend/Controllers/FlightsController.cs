using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHA.Data;
using GbrSchedulero;
using System.Dynamic;
using Microsoft.AspNetCore.Http;

namespace GbrWebFrontend.Controllers
{
    public class FlightsController : Controller
    {
        private readonly FlightScheduleDbContext _context;

        public FlightsController(FlightScheduleDbContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            //Huge query
            return View(await _context.Flights
                .Include(fl => fl.Plan)
                .Include(fl => fl.CrewAssignments)
                .ThenInclude(a => a.Qualification)
                .ThenInclude(q => q.Crewmember)
                .Include(fl => fl.Ship)
                .ThenInclude(sh => sh.AcType)
                .ToListAsync());
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            NewFlightViewModel model = new NewFlightViewModel();
            model.Flights = null;
            model.Airports = _context.Airports
                .Where(a => true)
                .AsEnumerable();
            model.Aircrafts = _context.Aircrafts
                .Where(a => true)
                .Include(a => a.AcType)
                .AsEnumerable();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateFlight(string flightNumber, int aircraftId, int originSelection, int destinationSelection,
            DateTime departDate, DateTime arriveDate)
        {
            FlightPlan plan = new FlightPlan(flightNumber, originSelection, destinationSelection, departDate, arriveDate);
            _context.Add(plan);

            Aircraft ac = _context.Aircrafts.Where(ac => ac.AircraftID == aircraftId).FirstOrDefault();

            Flight flight = new Flight(plan, ac, 0);

            _context.Add(flight);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult EditFlight(IFormCollection formCollection)
        {
            IEnumerable<int> ids = null;
            if (!string.IsNullOrEmpty(formCollection["qualificationID"]))
            {
                string qualificationIDs = formCollection["qualificationID"];
                ids = qualificationIDs.Split(",").Select(a => int.Parse(a));
                
                //No selection
                if (ids == null || ids.Count() == 0)
                    return RedirectToAction(nameof(Index));
            }

            int flightId = int.Parse(formCollection["flightId"]);
            Flight flight = _context.Flights.Where(fl => fl.FlightID == flightId).FirstOrDefault();

            //Add crewmembers to flight
            IEnumerable<CrewQualification> quals = _context.Qualifications.Where(q => ids.Contains(q.CrewQualificationID));

            foreach (CrewQualification qual in quals)
            {
                FlightCrewAssignment assignment = new FlightCrewAssignment(flight, qual);
                _context.Add(assignment);
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            AircraftType type = _context.Flights
                .Where(fl => fl.FlightID == id)
                .Include(fl => fl.Ship)
                .ThenInclude(s => s.AcType)
                .FirstOrDefault().Ship.AcType;

            //IEnumerable<FlightCrewAssignment> currentCrew = (from q in _context.Qualifications
            //                  join a in _context.Assignments on q.CrewQualificationID equals a.CrewQualificationID
            //                  join c in _context.Crewmembers on q.CrewmemberID equals c.CrewmemberID
            //                  where a.FlightID == (int)id
            //                  select a);

            IEnumerable<FlightCrewAssignment> currentCrew = _context.Assignments
                .Where(a => a.FlightID == (int)id)
                .Include(a => a.Qualification)
                .ThenInclude(q => q.Crewmember)
                .AsEnumerable();
                
            //What
            IEnumerable<CrewAssignmentViewLine> model = (from c in _context.Crewmembers
                              join q in _context.Qualifications on c.CrewmemberID equals q.CrewmemberID
                              join t in _context.AircraftTypes on q.AircraftTypeID equals t.AircraftTypeID
                              where t.AircraftTypeID == type.AircraftTypeID
                              orderby q.Station
                              select new CrewAssignmentViewLine{
                                  CrewQual = new CrewQualification{
                                      CrewQualificationID = q.CrewQualificationID,
                                      Station = q.Station,
                                      Crewmember = c
                                  },
                              });

            return View(new CrewAssignmentViewModel {FlightID = (int)id, Lines = model, CurrentCrew = currentCrew });
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightID,Passengers")] Flight flight)
        {
            if (id != flight.FlightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.FlightID == id);
        }
    }
}
