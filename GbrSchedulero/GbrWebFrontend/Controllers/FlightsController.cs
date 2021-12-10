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
                .Include(fl => fl.Crewmembers)
                .ThenInclude(e => e.Crewmember)
                .ThenInclude(c => c.Qualifications)
                .Include(fl => fl.Ship)
                .ThenInclude(sh => sh.AcType)
                .ToListAsync());
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            dynamic model = new ExpandoObject();
            model.Flight = null;
            model.Airports = _context.Airports.Where(a => true).AsEnumerable();
            model.Aircrafts = _context.Aircrafts.Where(a => true).AsEnumerable();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateFlight(string flightNumber)
        {
            //Add a dummy flight for now
            FlightPlan plan = _context.FlightPlans.Where(fp => fp.FlightPlanID == 1).FirstOrDefault();
            Aircraft ac = _context.Aircrafts.Where(ac => ac.AircraftID == 1).FirstOrDefault();

            Flight dummy = new Flight(plan, ac, 12);
            _context.Add(dummy);
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
            return View(flight);
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
