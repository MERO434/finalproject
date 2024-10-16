using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class DischargeSummariesController : Controller
    {
        private readonly HospitalContext _context;

        public DischargeSummariesController(HospitalContext context)
        {
            _context = context;
        }

        // GET: DischargeSummaries
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.DischargeSummaries.Include(d => d.Patient);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: DischargeSummaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dischargeSummary = await _context.DischargeSummaries
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.DischargeSummaryId == id);
            if (dischargeSummary == null)
            {
                return NotFound();
            }

            return View(dischargeSummary);
        }

        // GET: DischargeSummaries/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            return View();
        }

        // POST: DischargeSummaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DischargeSummaryId,PatientId,DischargeDate,FinalDiagnosis,PrescribedMedication,FollowUpInstructions")] DischargeSummary dischargeSummary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dischargeSummary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", dischargeSummary.PatientId);
            return View(dischargeSummary);
        }

        // GET: DischargeSummaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dischargeSummary = await _context.DischargeSummaries.FindAsync(id);
            if (dischargeSummary == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", dischargeSummary.PatientId);
            return View(dischargeSummary);
        }

        // POST: DischargeSummaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DischargeSummaryId,PatientId,DischargeDate,FinalDiagnosis,PrescribedMedication,FollowUpInstructions")] DischargeSummary dischargeSummary)
        {
            if (id != dischargeSummary.DischargeSummaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dischargeSummary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DischargeSummaryExists(dischargeSummary.DischargeSummaryId))
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
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", dischargeSummary.PatientId);
            return View(dischargeSummary);
        }

        // GET: DischargeSummaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dischargeSummary = await _context.DischargeSummaries
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.DischargeSummaryId == id);
            if (dischargeSummary == null)
            {
                return NotFound();
            }

            return View(dischargeSummary);
        }

        // POST: DischargeSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dischargeSummary = await _context.DischargeSummaries.FindAsync(id);
            if (dischargeSummary != null)
            {
                _context.DischargeSummaries.Remove(dischargeSummary);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DischargeSummaryExists(int id)
        {
            return _context.DischargeSummaries.Any(e => e.DischargeSummaryId == id);
        }
    }
}
