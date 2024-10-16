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
    public class SurgeriesController : Controller
    {
        private readonly HospitalContext _context;

        public SurgeriesController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Surgeries
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.Surgeries.Include(s => s.Doctor).Include(s => s.Patient);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: Surgeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery = await _context.Surgeries
                .Include(s => s.Doctor)
                .Include(s => s.Patient)
                .FirstOrDefaultAsync(m => m.SurgeryId == id);
            if (surgery == null)
            {
                return NotFound();
            }

            return View(surgery);
        }

        // GET: Surgeries/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorId");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            return View();
        }

        // POST: Surgeries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SurgeryId,PatientId,DoctorId,SurgeryType,SurgeryDate,OperationTheater,Status")] Surgery surgery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surgery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorId", surgery.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", surgery.PatientId);
            return View(surgery);
        }

        // GET: Surgeries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery = await _context.Surgeries.FindAsync(id);
            if (surgery == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorId", surgery.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", surgery.PatientId);
            return View(surgery);
        }

        // POST: Surgeries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SurgeryId,PatientId,DoctorId,SurgeryType,SurgeryDate,OperationTheater,Status")] Surgery surgery)
        {
            if (id != surgery.SurgeryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surgery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurgeryExists(surgery.SurgeryId))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorId", surgery.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", surgery.PatientId);
            return View(surgery);
        }

        // GET: Surgeries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery = await _context.Surgeries
                .Include(s => s.Doctor)
                .Include(s => s.Patient)
                .FirstOrDefaultAsync(m => m.SurgeryId == id);
            if (surgery == null)
            {
                return NotFound();
            }

            return View(surgery);
        }

        // POST: Surgeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surgery = await _context.Surgeries.FindAsync(id);
            if (surgery != null)
            {
                _context.Surgeries.Remove(surgery);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurgeryExists(int id)
        {
            return _context.Surgeries.Any(e => e.SurgeryId == id);
        }
    }
}
