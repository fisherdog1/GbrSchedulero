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
    public class CrewmembersController : Controller
    {
        private readonly FlightScheduleDbContext _context;

        public CrewmembersController(FlightScheduleDbContext context)
        {
            _context = context;
        }

        // GET: Crewmembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Crewmembers
                .Include(a => a.Qualifications)
                .ThenInclude(q => q.AcType)
                .ToListAsync());

        }

        // GET: Crewmembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var crewmember = await _context.Crewmembers
            //.FirstOrDefaultAsync(m => m.CrewmemberID == id);
            var crewmember = await _context.Crewmembers
                .Include(b => b.Qualifications)
                .ThenInclude(q => q.AcType)
                .FirstOrDefaultAsync(m => m.CrewmemberID == id);

            if (crewmember == null)
            {
                return NotFound();
            }

            return View(crewmember);
        }

        // GET: Crewmembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crewmembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CrewmemberID,FirstName,LastName")] Crewmember crewmember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crewmember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crewmember);
        }

        // GET: Crewmembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crewmember = await _context.Crewmembers.FindAsync(id);
            if (crewmember == null)
            {
                return NotFound();
            }
            return View(crewmember);
        }

        // POST: Crewmembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CrewmemberID,FirstName,LastName")] Crewmember crewmember)
        {
            if (id != crewmember.CrewmemberID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crewmember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrewmemberExists(crewmember.CrewmemberID))
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
            return View(crewmember);
        }

        // GET: Crewmembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crewmember = await _context.Crewmembers
                .FirstOrDefaultAsync(m => m.CrewmemberID == id);
            if (crewmember == null)
            {
                return NotFound();
            }

            return View(crewmember);
        }

        // POST: Crewmembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crewmember = await _context.Crewmembers.FindAsync(id);
            _context.Crewmembers.Remove(crewmember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrewmemberExists(int id)
        {
            return _context.Crewmembers.Any(e => e.CrewmemberID == id);
        }
    }
}
