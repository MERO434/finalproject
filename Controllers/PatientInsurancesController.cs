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
    public class PatientInsurancesController : Controller
    {
        private readonly HospitalContext _context;

        public PatientInsurancesController(HospitalContext context)
        {
            _context = context;
        }

        // GET: PatientInsurances
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.PatientInsurances.Include(p => p.Patient).Include(p => p.Provider);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: PatientInsurances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInsurance = await _context.PatientInsurances
                .Include(p => p.Patient)
                .Include(p => p.Provider)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patientInsurance == null)
            {
                return NotFound();
            }

            return View(patientInsurance);
        }

        // GET: PatientInsurances/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            ViewData["ProviderId"] = new SelectList(_context.InsuranceProviders, "ProviderId", "ProviderId");
            return View();
        }

        // POST: PatientInsurances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,ProviderId,PolicyNumber,CoverageDetails,ExpirationDate")] PatientInsurance patientInsurance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientInsurance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", patientInsurance.PatientId);
            ViewData["ProviderId"] = new SelectList(_context.InsuranceProviders, "ProviderId", "ProviderId", patientInsurance.ProviderId);
            return View(patientInsurance);
        }

        // GET: PatientInsurances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInsurance = await _context.PatientInsurances.FindAsync(id);
            if (patientInsurance == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", patientInsurance.PatientId);
            ViewData["ProviderId"] = new SelectList(_context.InsuranceProviders, "ProviderId", "ProviderId", patientInsurance.ProviderId);
            return View(patientInsurance);
        }

        // POST: PatientInsurances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,ProviderId,PolicyNumber,CoverageDetails,ExpirationDate")] PatientInsurance patientInsurance)
        {
            if (id != patientInsurance.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientInsurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientInsuranceExists(patientInsurance.PatientId))
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
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", patientInsurance.PatientId);
            ViewData["ProviderId"] = new SelectList(_context.InsuranceProviders, "ProviderId", "ProviderId", patientInsurance.ProviderId);
            return View(patientInsurance);
        }

        // GET: PatientInsurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInsurance = await _context.PatientInsurances
                .Include(p => p.Patient)
                .Include(p => p.Provider)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patientInsurance == null)
            {
                return NotFound();
            }

            return View(patientInsurance);
        }

        // POST: PatientInsurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientInsurance = await _context.PatientInsurances.FindAsync(id);
            if (patientInsurance != null)
            {
                _context.PatientInsurances.Remove(patientInsurance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientInsuranceExists(int id)
        {
            return _context.PatientInsurances.Any(e => e.PatientId == id);
        }
    }
}
