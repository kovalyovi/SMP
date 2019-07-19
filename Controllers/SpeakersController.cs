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
    public class SpeakersController : Controller
    {
        private readonly SacramentMeetingPlannerContext _context;

        public SpeakersController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: Speakers
        public async Task<IActionResult> Index()
        {
            var speakersContext = _context.Speakers.Include(s => s.Speaker).Include(s => s.SMP);
            return View(await speakersContext.ToListAsync());
        }

        // GET: Speakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakers = await _context.Speakers
                .Include(s => s.Speaker)
                .Include(s => s.SMP)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (speakers == null)
            {
                return NotFound();
            }

            return View(speakers);
        }

        // GET: Speakers/Create
        public IActionResult Create(int SMPID)
        {
            var members = _context.Member.Select(s => new
            {
                ID = s.ID,
                FullName = string.Format("{0} {1}", s.FirstName, s.LastName)
            }).ToList();

            var selectedValue = _context.SMP.Where(s => s.ID == SMPID);

            ViewData["SpeakerID"] = new SelectList(members, "ID", "FullName");
            ViewData["SMPID"] = new SelectList(_context.SMP, "ID", "ID", selectedValue);
            return View();
        }



        // POST: Speakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SpeakerID,Topic,SMPID")] Speakers speakers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speakers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SpeakerID"] = new SelectList(_context.Member, "ID", "ID", speakers.SpeakerID);
            ViewData["SMPID"] = new SelectList(_context.SMP, "ID", "ID", speakers.SMPID);

            return RedirectToAction("Create", new { id = speakers.SMPID});
        }

        // GET: Speakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakers = await _context.Speakers.FindAsync(id);
            if (speakers == null)
            {
                return NotFound();
            }

            var members = _context.Member.Select(s => new
            {
                ID = s.ID,
                FullName = string.Format("{0} {1}", s.FirstName, s.LastName)
            }).ToList();

            ViewData["SpeakerID"] = new SelectList(members, "ID", "FullName", speakers.SpeakerID);
            ViewData["SMPID"] = new SelectList(_context.SMP, "ID", "ID", speakers.SMPID);

            return View(speakers);
        }

        // POST: Speakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SpeakerID,Topic,SMPID")] Speakers speakers)
        {
            if (id != speakers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speakers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakersExists(speakers.ID))
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

            ViewData["SpeakerID"] = new SelectList(_context.Member, "ID", "ID", speakers.SpeakerID);
            ViewData["SMPID"] = new SelectList(_context.SMP, "ID", "ID", speakers.SMPID);
            return View(speakers);
        }

        // GET: Speakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakers = await _context.Speakers
                .Include(s => s.Speaker)
                .Include(s => s.SMP)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (speakers == null)
            {
                return NotFound();
            }

            return View(speakers);
        }

        // POST: Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speakers = await _context.Speakers.FindAsync(id);
            _context.Speakers.Remove(speakers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeakersExists(int id)
        {
            return _context.Speakers.Any(e => e.ID == id);
        }
    }
}
