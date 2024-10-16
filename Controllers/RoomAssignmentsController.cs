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
    public class RoomAssignmentsController : Controller
    {
        private readonly HospitalContext _context;

        public RoomAssignmentsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: RoomAssignments
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.RoomAssignments.Include(r => r.Patient).Include(r => r.Room);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: RoomAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAssignment = await _context.RoomAssignments
                .Include(r => r.Patient)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomAssignmentId == id);
            if (roomAssignment == null)
            {
                return NotFound();
            }

            return View(roomAssignment);
        }

        // GET: RoomAssignments/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
            return View();
        }

        // POST: RoomAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomAssignmentId,PatientId,RoomId,StartDate,EndDate")] RoomAssignment roomAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", roomAssignment.PatientId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", roomAssignment.RoomId);
            return View(roomAssignment);
        }

        // GET: RoomAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAssignment = await _context.RoomAssignments.FindAsync(id);
            if (roomAssignment == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", roomAssignment.PatientId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", roomAssignment.RoomId);
            return View(roomAssignment);
        }

        // POST: RoomAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomAssignmentId,PatientId,RoomId,StartDate,EndDate")] RoomAssignment roomAssignment)
        {
            if (id != roomAssignment.RoomAssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomAssignmentExists(roomAssignment.RoomAssignmentId))
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
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", roomAssignment.PatientId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", roomAssignment.RoomId);
            return View(roomAssignment);
        }

        // GET: RoomAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAssignment = await _context.RoomAssignments
                .Include(r => r.Patient)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomAssignmentId == id);
            if (roomAssignment == null)
            {
                return NotFound();
            }

            return View(roomAssignment);
        }

        // POST: RoomAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomAssignment = await _context.RoomAssignments.FindAsync(id);
            if (roomAssignment != null)
            {
                _context.RoomAssignments.Remove(roomAssignment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAssignmentExists(int id)
        {
            return _context.RoomAssignments.Any(e => e.RoomAssignmentId == id);
        }
    }
}
