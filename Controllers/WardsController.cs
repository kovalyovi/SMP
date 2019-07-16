using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class WardsController : Controller
    {
        private readonly SacramentMeetingPlannerContext _context;

        public WardsController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: Wards
        public async Task<IActionResult> Index()
        {
            var sacramentMeetingPlannerContext = _context.Ward.Include(w => w.Bishop).Include(w => w.First).Include(w => w.Second);
            return View(await sacramentMeetingPlannerContext.ToListAsync());
        }

        // GET: Wards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Ward
                .Include(w => w.Bishop)
                .Include(w => w.First)
                .Include(w => w.Second)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ward == null)
            {
                return NotFound();
            }

            return View(ward);
        }

        // GET: Wards/Create
        public IActionResult Create()
        {
            ViewData["BishopID"] = new SelectList(_context.Member, "ID", "ID");
            ViewData["FirstID"] = new SelectList(_context.Member, "ID", "ID");
            ViewData["SecondID"] = new SelectList(_context.Member, "ID", "ID");
            return View();
        }

        // POST: Wards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,BishopID,FirstID,SecondID")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ward);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BishopID"] = new SelectList(_context.Member, "ID", "ID", ward.BishopID);
            ViewData["FirstID"] = new SelectList(_context.Member, "ID", "ID", ward.FirstID);
            ViewData["SecondID"] = new SelectList(_context.Member, "ID", "ID", ward.SecondID);
            return View(ward);
        }

        // GET: Wards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Ward.FindAsync(id);
            if (ward == null)
            {
                return NotFound();
            }
            ViewData["BishopID"] = new SelectList(_context.Member, "ID", "ID", ward.BishopID);
            ViewData["FirstID"] = new SelectList(_context.Member, "ID", "ID", ward.FirstID);
            ViewData["SecondID"] = new SelectList(_context.Member, "ID", "ID", ward.SecondID);
            return View(ward);
        }

        // POST: Wards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,BishopID,FirstID,SecondID")] Ward ward)
        {
            if (id != ward.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ward);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WardExists(ward.ID))
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
            ViewData["BishopID"] = new SelectList(_context.Member, "ID", "ID", ward.BishopID);
            ViewData["FirstID"] = new SelectList(_context.Member, "ID", "ID", ward.FirstID);
            ViewData["SecondID"] = new SelectList(_context.Member, "ID", "ID", ward.SecondID);
            return View(ward);
        }

        // GET: Wards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Ward
                .Include(w => w.Bishop)
                .Include(w => w.First)
                .Include(w => w.Second)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ward == null)
            {
                return NotFound();
            }

            return View(ward);
        }

        // POST: Wards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ward = await _context.Ward.FindAsync(id);
            _context.Ward.Remove(ward);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WardExists(int id)
        {
            return _context.Ward.Any(e => e.ID == id);
        }
    }
}
