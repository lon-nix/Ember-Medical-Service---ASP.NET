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

    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _Appointmentrepo;
        private readonly IMapper _Dbmapper;

        public AppointmentController(IAppointmentRepository Appointmentrepo, IMapper Dbmapper)
        {
            _Appointmentrepo = Appointmentrepo;
            _Dbmapper = Dbmapper;


        }
        // GET: Appointment
        public ActionResult Index()
        {
            var AppointmentList = _Appointmentrepo.FindAll();
            var AppointmentMapper = _Dbmapper.Map<ICollection<Appointment>, ICollection<ListOfAppointmentVM>>(AppointmentList);
            return View(AppointmentMapper);
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            if (!_Appointmentrepo.IsExist(id))
            {
                return NotFound();
            }
            var appointment = _Appointmentrepo.FindByID(id);
            var AppointmentDetail = _Dbmapper.Map<ListOfAppointmentVM>(appointment);

            return View(AppointmentDetail);
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAppointmentVM appointment)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(appointment);
                }
                var CreateAppointment = _Dbmapper.Map<Appointment>(appointment);
                //Appointment.CreatedDate = DateTime.Now; 
                var successful = _Appointmentrepo.Create(CreateAppointment);

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

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_Appointmentrepo.IsExist(id))
            {
                return NotFound();
            }
            var appointment = _Appointmentrepo.FindByID(id);
            var AppointmentUpdate = _Dbmapper.Map<ListOfAppointmentVM>(appointment);

            return View(AppointmentUpdate);
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ListOfAppointmentVM appointment)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(appointment);
                }
                var EditAppointment = _Dbmapper.Map<Appointment>(appointment);
                var successful = _Appointmentrepo.Update(EditAppointment);

                if (!successful)
                {
                    ModelState.AddModelError("", "Error processing request");
                    return View(appointment);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            var Appt = _Appointmentrepo.FindByID(id);
            if (Appt == null)
            {
                return NotFound();
            }
            var successful = _Appointmentrepo.Delete(Appt);

            if (!successful)
            {

                return BadRequest();
            }



            return RedirectToAction(nameof(Index));
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ListOfAppointmentVM appointment)
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