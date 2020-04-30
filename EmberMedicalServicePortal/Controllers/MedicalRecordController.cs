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
    public class MedicalRecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicalRecordController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicalRecord
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalHistory.ToListAsync());
        }

        // GET: MedicalRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalHistoryVM = await _context.MedicalHistory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medicalHistoryVM == null)
            {
                return NotFound();
            }

            return View(medicalHistoryVM);
        }

        // GET: MedicalRecord/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalRecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PatientID,CreatedDate,Weight_lb,Height_cm,Blood_Sugar,Blood_Pressure,Symptoms,Diagnosis,Prescription,Comments")] MedicalHistoryVM medicalHistoryVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalHistoryVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalHistoryVM);
        }

        // GET: MedicalRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalHistoryVM = await _context.MedicalHistory.FindAsync(id);
            if (medicalHistoryVM == null)
            {
                return NotFound();
            }
            return View(medicalHistoryVM);
        }

        // POST: MedicalRecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PatientID,CreatedDate,Weight_lb,Height_cm,Blood_Sugar,Blood_Pressure,Symptoms,Diagnosis,Prescription,Comments")] MedicalHistoryVM medicalHistoryVM)
        {
            if (id != medicalHistoryVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalHistoryVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalHistoryVMExists(medicalHistoryVM.ID))
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
            return View(medicalHistoryVM);
        }

        [Authorize(Roles = "Administrator")]
        // GET: MedicalRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalHistoryVM = await _context.MedicalHistory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medicalHistoryVM == null)
            {
                return NotFound();
            }

            return View(medicalHistoryVM);
        }

        // POST: MedicalRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalHistoryVM = await _context.MedicalHistory.FindAsync(id);
            _context.MedicalHistory.Remove(medicalHistoryVM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalHistoryVMExists(int id)
        {
            return _context.MedicalHistory.Any(e => e.ID == id);
        }
    }
}
