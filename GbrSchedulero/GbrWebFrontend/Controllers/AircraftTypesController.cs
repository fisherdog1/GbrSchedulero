using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHA.Data;
using GbrSchedulero;

namespace GbrWebFrontend.Controllers
{
    public class AircraftTypesController : Controller
    {
        private readonly FlightScheduleDbContext _context;

        public AircraftTypesController(FlightScheduleDbContext context)
        {
            _context = context;
        }

        // GET: AircraftTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AircraftTypes.ToListAsync());
        }

        // GET: AircraftTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraftType = await _context.AircraftTypes
                .FirstOrDefaultAsync(m => m.AircraftTypeID == id);
            if (aircraftType == null)
            {
                return NotFound();
            }

            return View(aircraftType);
        }

        // GET: AircraftTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AircraftTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AircraftTypeID,TypeName,MaxPassengers")] AircraftType aircraftType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aircraftType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aircraftType);
        }

        // GET: AircraftTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraftType = await _context.AircraftTypes.FindAsync(id);
            if (aircraftType == null)
            {
                return NotFound();
            }
            return View(aircraftType);
        }

        // POST: AircraftTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AircraftTypeID,TypeName,MaxPassengers")] AircraftType aircraftType)
        {
            if (id != aircraftType.AircraftTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aircraftType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AircraftTypeExists(aircraftType.AircraftTypeID))
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
            return View(aircraftType);
        }

        // GET: AircraftTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraftType = await _context.AircraftTypes
                .FirstOrDefaultAsync(m => m.AircraftTypeID == id);
            if (aircraftType == null)
            {
                return NotFound();
            }

            return View(aircraftType);
        }

        // POST: AircraftTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aircraftType = await _context.AircraftTypes.FindAsync(id);
            _context.AircraftTypes.Remove(aircraftType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AircraftTypeExists(int id)
        {
            return _context.AircraftTypes.Any(e => e.AircraftTypeID == id);
        }
    }
}
