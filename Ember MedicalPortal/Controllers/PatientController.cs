using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ember_Medical_Service.Contracts;
using Ember_Medical_Service.Data;
using Ember_Medical_Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ember_Medical_Service.Controllers
{
    [Authorize]

    public class PatientController : Controller
    {
        private readonly IPatientRepository _Patientrepo;
        private readonly IMapper _Dbmapper;

        public PatientController(IPatientRepository Patientrepo, IMapper Dbmapper)
        {
            _Patientrepo = Patientrepo;
            _Dbmapper = Dbmapper;


        }

        // GET: Patient
        public ActionResult Index()
        {
            var Patients = _Patientrepo.FindAll().ToList();
            var PatientMapper = _Dbmapper.Map<List<Patient>, List< PatientInfoVM>> (Patients);
            return View(PatientMapper);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            if (!_Patientrepo.IsExist(id))
            {
                return NotFound();
            }
            var patient = _Patientrepo.FindByID(id);
            var PatientDetail = _Dbmapper.Map<PatientInfoVM>(patient);

            return View(PatientDetail);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePatientVM patient)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(patient);
                }
                var CreatePatient = _Dbmapper.Map<Patient>(patient);

                //Patient.CreatedDate = DateTime.Now; 

                var successful = _Patientrepo.Create(CreatePatient);

                if (!successful)
                {
                    ModelState.AddModelError("", "Error processing request");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_Patientrepo.IsExist(id))
            {
                return NotFound();
            }
            var patient = _Patientrepo.FindByID(id);
            var PatientUpdate = _Dbmapper.Map<PatientInfoVM>(patient);

            return View(PatientUpdate);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientInfoVM patient)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(patient);
                }
                var EditPatient = _Dbmapper.Map<Patient>(patient);
                var successful = _Patientrepo.Update(EditPatient);

                if (!successful)
                {
                    ModelState.AddModelError("", "Error processing request");
                    return View(patient);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            var member = _Patientrepo.FindByID(id);
            if (member == null)
            {
                return NotFound();
            }
            var successful = _Patientrepo.Delete(member);

            if (!successful)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Patient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PatientInfoVM patient)
        {
            try
            {
                // TODO: Add delete logic here
               

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}