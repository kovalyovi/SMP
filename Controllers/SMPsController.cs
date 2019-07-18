﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class SMPsController : Controller
    {
        private readonly SacramentMeetingPlannerContext _context;

        public SMPsController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: SMPs
        public async Task<IActionResult> Index()
        {
            var sacramentMeetingPlannerContext = _context.SMP.Include(s => s.Benediction).Include(s => s.ClosingHymn).Include(s => s.Conducting).Include(s => s.IntermediateHymn).Include(s => s.Invocation).Include(s => s.OpeningHymn).Include(s => s.Presiding).Include(s => s.SacramentHymn).Include(s => s.Ward);
            return View(await sacramentMeetingPlannerContext.ToListAsync());
        }

        // GET: SMPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sMP = await _context.SMP
                .Include(s => s.Benediction)
                .Include(s => s.ClosingHymn)
                .Include(s => s.Conducting)
                .Include(s => s.IntermediateHymn)
                .Include(s => s.Invocation)
                .Include(s => s.OpeningHymn)
                .Include(s => s.Presiding)
                .Include(s => s.SacramentHymn)
                .Include(s => s.Ward)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sMP == null)
            {
                return NotFound();
            }

            return View(sMP);
        }

        // GET: SMPs/Create
        public IActionResult Create()
        {
            ViewData["BenedictionID"] = _context.Member.Select(i => new SelectListItem
            {
                Value = i.ID.ToString(),
                Text = i.FirstName + " " + i.LastName
            }).ToList();
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "ID");
            ViewData["ConductingID"] = _context.Member.Select(i => new SelectListItem
            {
                Value = i.ID.ToString(),
                Text = i.FirstName + " " + i.LastName
            }).ToList();
            ViewData["IntermediateHymnID"] = new SelectList(_context.Hymn, "ID", "ID");
            ViewData["InvocationID"] = _context.Member.Select(i => new SelectListItem
            {
                Value = i.ID.ToString(),
                Text = i.FirstName + " " + i.LastName
            }).ToList();
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "ID");
            ViewData["PresidingID"] = _context.Member.Select(i => new SelectListItem
            {
                Value = i.ID.ToString(),
                Text = i.FirstName + " " + i.LastName
            }).ToList();
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "ID");
            ViewData["WardID"] = new SelectList(_context.Ward, "ID", "ID");
            return View();
        }

        // POST: SMPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,WardID,PresidingID,ConductingID,Date,OpeningHymnID,SacramentHymnID,IntermediateHymnID,ClosingHymnID,InvocationID,BenedictionID")] SMP sMP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sMP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BenedictionID"] = new SelectList(_context.Member, "ID", "ID", sMP.BenedictionID);
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.ClosingHymnID);
            ViewData["ConductingID"] = new SelectList(_context.Member, "ID", "ID", sMP.ConductingID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.IntermediateHymnID);
            ViewData["InvocationID"] = new SelectList(_context.Member, "ID", "ID", sMP.InvocationID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.OpeningHymnID);
            ViewData["PresidingID"] = new SelectList(_context.Member, "ID", "ID", sMP.PresidingID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.SacramentHymnID);
            ViewData["WardID"] = new SelectList(_context.Ward, "ID", "ID", sMP.WardID);
            return View(sMP);
        }

        // GET: SMPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sMP = await _context.SMP.FindAsync(id);
            if (sMP == null)
            {
                return NotFound();
            }
            ViewData["BenedictionID"] = new SelectList(_context.Member, "ID", "ID", sMP.BenedictionID);
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.ClosingHymnID);
            ViewData["ConductingID"] = new SelectList(_context.Member, "ID", "ID", sMP.ConductingID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.IntermediateHymnID);
            ViewData["InvocationID"] = new SelectList(_context.Member, "ID", "ID", sMP.InvocationID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.OpeningHymnID);
            ViewData["PresidingID"] = new SelectList(_context.Member, "ID", "ID", sMP.PresidingID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.SacramentHymnID);
            ViewData["WardID"] = new SelectList(_context.Ward, "ID", "ID", sMP.WardID);
            return View(sMP);
        }

        // POST: SMPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,WardID,PresidingID,ConductingID,Date,OpeningHymnID,SacramentHymnID,IntermediateHymnID,ClosingHymnID,InvocationID,BenedictionID")] SMP sMP)
        {
            if (id != sMP.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sMP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SMPExists(sMP.ID))
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
            ViewData["BenedictionID"] = new SelectList(_context.Member, "ID", "ID", sMP.BenedictionID);
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.ClosingHymnID);
            ViewData["ConductingID"] = new SelectList(_context.Member, "ID", "ID", sMP.ConductingID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.IntermediateHymnID);
            ViewData["InvocationID"] = new SelectList(_context.Member, "ID", "ID", sMP.InvocationID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.OpeningHymnID);
            ViewData["PresidingID"] = new SelectList(_context.Member, "ID", "ID", sMP.PresidingID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "ID", sMP.SacramentHymnID);
            ViewData["WardID"] = new SelectList(_context.Ward, "ID", "ID", sMP.WardID);
            return View(sMP);
        }

        // GET: SMPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sMP = await _context.SMP
                .Include(s => s.Benediction)
                .Include(s => s.ClosingHymn)
                .Include(s => s.Conducting)
                .Include(s => s.IntermediateHymn)
                .Include(s => s.Invocation)
                .Include(s => s.OpeningHymn)
                .Include(s => s.Presiding)
                .Include(s => s.SacramentHymn)
                .Include(s => s.Ward)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sMP == null)
            {
                return NotFound();
            }

            return View(sMP);
        }

        // POST: SMPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sMP = await _context.SMP.FindAsync(id);
            _context.SMP.Remove(sMP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SMPExists(int id)
        {
            return _context.SMP.Any(e => e.ID == id);
        }
    }
}
