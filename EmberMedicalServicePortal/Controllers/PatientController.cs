using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmberMedicalServicePortal.Data;
using EmberMedicalServicePortal.Models;
using Microsoft.AspNetCore.Authorization;

namespace EmberMedicalServicePortal.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patient
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientInfo.ToListAsync());
        }

        // GET: Patient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInfoVM = await _context.PatientInfo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (patientInfoVM == null)
            {
                return NotFound();
            }

            return View(patientInfoVM);
        }

        // GET: Patient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,DateOfBirth,Address,Phone,Email")] PatientInfoVM patientInfoVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientInfoVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientInfoVM);
        }

        // GET: Patient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInfoVM = await _context.PatientInfo.FindAsync(id);
            if (patientInfoVM == null)
            {
                return NotFound();
            }
            return View(patientInfoVM);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,DateOfBirth,Address,Phone,Email")] PatientInfoVM patientInfoVM)
        {
            if (id != patientInfoVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientInfoVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientInfoVMExists(patientInfoVM.ID))
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
            return View(patientInfoVM);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Patient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInfoVM = await _context.PatientInfo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (patientInfoVM == null)
            {
                return NotFound();
            }

            return View(patientInfoVM);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientInfoVM = await _context.PatientInfo.FindAsync(id);
            _context.PatientInfo.Remove(patientInfoVM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientInfoVMExists(int id)
        {
            return _context.PatientInfo.Any(e => e.ID == id);
        }
    }
}
