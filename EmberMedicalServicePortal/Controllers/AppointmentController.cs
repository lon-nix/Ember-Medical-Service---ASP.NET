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
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointment
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppointmentList.ToListAsync());
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfAppointmentVM = await _context.AppointmentList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (listOfAppointmentVM == null)
            {
                return NotFound();
            }

            return View(listOfAppointmentVM);
        }

        // GET: Appointment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PatientID,ApptDate,ApptTime,Comment")] ListOfAppointmentVM listOfAppointmentVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfAppointmentVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listOfAppointmentVM);
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfAppointmentVM = await _context.AppointmentList.FindAsync(id);
            if (listOfAppointmentVM == null)
            {
                return NotFound();
            }
            return View(listOfAppointmentVM);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PatientID,ApptDate,ApptTime,Comment")] ListOfAppointmentVM listOfAppointmentVM)
        {
            if (id != listOfAppointmentVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfAppointmentVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfAppointmentVMExists(listOfAppointmentVM.ID))
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
            return View(listOfAppointmentVM);
        }

        [Authorize(Roles = "Administrator")]

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfAppointmentVM = await _context.AppointmentList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (listOfAppointmentVM == null)
            {
                return NotFound();
            }

            return View(listOfAppointmentVM);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfAppointmentVM = await _context.AppointmentList.FindAsync(id);
            _context.AppointmentList.Remove(listOfAppointmentVM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfAppointmentVMExists(int id)
        {
            return _context.AppointmentList.Any(e => e.ID == id);
        }
    }
}
