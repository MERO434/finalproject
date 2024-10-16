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
    public class InsuranceProvidersController : Controller
    {
        private readonly HospitalContext _context;

        public InsuranceProvidersController(HospitalContext context)
        {
            _context = context;
        }

        // GET: InsuranceProviders
        public async Task<IActionResult> Index()
        {
            return View(await _context.InsuranceProviders.ToListAsync());
        }

        // GET: InsuranceProviders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceProvider = await _context.InsuranceProviders
                .FirstOrDefaultAsync(m => m.ProviderId == id);
            if (insuranceProvider == null)
            {
                return NotFound();
            }

            return View(insuranceProvider);
        }

        // GET: InsuranceProviders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsuranceProviders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProviderId,ProviderName,ProviderContact,Phone,Email,Address")] InsuranceProvider insuranceProvider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuranceProvider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuranceProvider);
        }

        // GET: InsuranceProviders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceProvider = await _context.InsuranceProviders.FindAsync(id);
            if (insuranceProvider == null)
            {
                return NotFound();
            }
            return View(insuranceProvider);
        }

        // POST: InsuranceProviders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProviderId,ProviderName,ProviderContact,Phone,Email,Address")] InsuranceProvider insuranceProvider)
        {
            if (id != insuranceProvider.ProviderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceProvider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceProviderExists(insuranceProvider.ProviderId))
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
            return View(insuranceProvider);
        }

        // GET: InsuranceProviders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceProvider = await _context.InsuranceProviders
                .FirstOrDefaultAsync(m => m.ProviderId == id);
            if (insuranceProvider == null)
            {
                return NotFound();
            }

            return View(insuranceProvider);
        }

        // POST: InsuranceProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuranceProvider = await _context.InsuranceProviders.FindAsync(id);
            if (insuranceProvider != null)
            {
                _context.InsuranceProviders.Remove(insuranceProvider);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceProviderExists(int id)
        {
            return _context.InsuranceProviders.Any(e => e.ProviderId == id);
        }
    }
}
