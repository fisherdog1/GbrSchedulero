using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHA.Data;

namespace CHA.Controllers
{
    public class CrewmemsController : Controller
    {
        private readonly FlightScheduleDbContext _context;

        public CrewmemsController(FlightScheduleDbContext context)
        {
            _context = context;
        }

        // GET: Crewmems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Crewmembers.ToListAsync());
        }

        // GET: Crewmems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crewmem = await _context.Crewmembers
                .FirstOrDefaultAsync(m => m.CrewmemberID == id);
            if (crewmem == null)
            {
                return NotFound();
            }

            return View(crewmem);
        }

        // GET: Crewmems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crewmems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CrewID,FirstName,LastName")] Crewmem crewmem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crewmem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crewmem);
        }

        // GET: Crewmems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crewmem = await _context.Crewmembers.FindAsync(id);
            if (crewmem == null)
            {
                return NotFound();
            }
            return View(crewmem);
        }

        // POST: Crewmems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CrewID,FirstName,LastName")] Crewmem crewmem)
        {
            if (id != crewmem.CrewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crewmem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrewmemExists(crewmem.CrewID))
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
            return View(crewmem);
        }

        // GET: Crewmems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crewmem = await _context.Crewmembers
                .FirstOrDefaultAsync(m => m.CrewmemberID == id);
            if (crewmem == null)
            {
                return NotFound();
            }

            return View(crewmem);
        }

        // POST: Crewmems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crewmem = await _context.Crewmembers.FindAsync(id);
            _context.Crewmembers.Remove(crewmem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrewmemExists(int id)
        {
            return _context.Crewmembers.Any(e => e.CrewmemberID == id);
        }
    }
}
