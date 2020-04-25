using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ember_Medical_Service.Contracts;
using Ember_Medical_Service.Data;
using Ember_Medical_Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ember_Medical_Service.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordRepository _MedicalRecordrepo;
        private readonly IMapper _Dbmapper;

        public MedicalRecordController(IMedicalRecordRepository MedicalRecordrepo, IMapper Dbmapper)
        {
            _MedicalRecordrepo = MedicalRecordrepo;
            _Dbmapper = Dbmapper;


        }
        // GET: MedicalRecord
        public ActionResult Index()
        {
            var MedicalRecordList = _MedicalRecordrepo.FindAll();
            var MedicalRecordMapper = _Dbmapper.Map<ICollection<MedicalRecord>, ICollection<MedicalHistoryVM>>(MedicalRecordList);
            return View(MedicalRecordMapper);
        }

        // GET: MedicalRecord/Details/5
        public ActionResult Details(int id)
        {
            if (!_MedicalRecordrepo.IsExist(id))
            {
                return NotFound();
            }
            var medicalrecord = _MedicalRecordrepo.FindByID(id);
            var MedicalRecordDetail = _Dbmapper.Map<MedicalHistoryVM>(medicalrecord);

            return View(MedicalRecordDetail);
        }

        // GET: MedicalRecord/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalRecord/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMedicalRecordVM medicalrecord)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(medicalrecord);
                }
                var CreateMedicalrecord = _Dbmapper.Map<MedicalRecord>(medicalrecord);

                medicalrecord.CreatedDate = DateTime.Now;
                


                var successful = _MedicalRecordrepo.Create(CreateMedicalrecord);

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

        // GET: MedicalRecord/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_MedicalRecordrepo.IsExist(id))
            {
                return NotFound();
            }
            var medicalrecord = _MedicalRecordrepo.FindByID(id);
            var MedicalRecordUpdate = _Dbmapper.Map<MedicalHistoryVM>(medicalrecord);

            return View(MedicalRecordUpdate);
        }

        // POST: MedicalRecord/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicalHistoryVM MedicalHistory)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(MedicalHistory);
                }
                var EditMedicalHistory = _Dbmapper.Map<MedicalRecord>(MedicalHistory);
                var successful = _MedicalRecordrepo.Update(EditMedicalHistory);

                if (!successful)
                {
                    ModelState.AddModelError("", "Error processing request");
                    return View(MedicalHistory);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicalRecord/Delete/5
        public ActionResult Delete(int id)
        {
            var medicalrecord = _MedicalRecordrepo.FindByID(id);
            if (medicalrecord == null)
            {
                return NotFound();
            }
            var successful = _MedicalRecordrepo.Delete(medicalrecord);

            if (!successful)
            {

                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: MedicalRecord/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MedicalRecord medicalRecord)
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