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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ember_Medical_Service.Controllers
{

    // From Mr. Williams: This is now fixed!! You can proceed. Let me know if you need more help. 
    [Authorize(Roles = "Administrator")]

    public class StaffController : Controller
    {
        private readonly IStaffRepository _Staffrepo;
        private readonly IPositionRepository _Positionrepo;
        private readonly IMapper _Dbmapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public StaffController(IStaffRepository Staffrepo, IPositionRepository _PositionRepo, IMapper Dbmapper,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _Staffrepo = Staffrepo;
            _Dbmapper = Dbmapper;
            _Positionrepo = _PositionRepo;
            _userManager = userManager;
            _signInManager = signInManager;


        }
        // GET: Staff
        public ActionResult Index()
        {

            /*var StaffInfo = _Staffrepo.FindAll();
            //var StaffMapper = _Dbmapper.Map<ICollection<Staff>, ICollection<StaffInfoVM>>(StaffInfo);*/

            return View();
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            if (!_Staffrepo.IsExist(id))
            {
                return NotFound();
            }
            var staff = _Staffrepo.FindByID(id);
            var StaffDetail = _Dbmapper.Map<StaffInfoVM>(staff);

            return View(StaffDetail);
        }
    

        
        

        // GET: Staff/Create
        public  ActionResult Create()
        {

            return View();


        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateStaffVM staff)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    /*var user = new IdentityUser { UserName = staff.Email, Email = staff.Email };
                    _userManager.CreateAsync(user);*/
                    return View(staff);
                }
                /*
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(staff);
                }
                var CreateStaff = _Dbmapper.Map<Staff>(staff);

                //Patient.CreatedDate = DateTime.Now; 

                var successful = _Staffrepo.Create(CreateStaff);

                if (!successful)
                {
                    ModelState.AddModelError("", "Error processing request");
                }*/

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_Staffrepo.IsExist(id))
            {
                return NotFound();
            }
            var staff = _Staffrepo.FindByID(id);
            var StaffUpdate = _Dbmapper.Map<StaffInfoVM>(staff);

            return View(StaffUpdate);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffInfoVM staff)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    
                    return View(staff);
                }
                var EditStaff = _Dbmapper.Map<Staff>(staff);
                var successful = _Staffrepo.Update(EditStaff);

                if (!successful)
                {
                    ModelState.AddModelError("", "Error processing request");
                    return View(staff);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            var member = _Staffrepo.FindByID(id);
            if (member == null)
            {
                return NotFound();
            }
            var successful = _Staffrepo.Delete(member);

            if (!successful)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Staff/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, StaffInfoVM staff)
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