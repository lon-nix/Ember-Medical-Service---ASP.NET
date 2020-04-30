using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmberMedicalServicePortal.Data;
using EmberMedicalServicePortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace EmberMedicalServicePortal.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager; 

        public EmployeeController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        // GET: Employee
        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            
               return View(await _userManager.Users.ToListAsync());
            }

            // GET: Employee/Details/5
            public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeVM = await _userManager.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeVM == null)
            {
                return NotFound();
            }

            return View(employeeVM);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,FirstName,LastName,Email,PhoneNumber,Address,UserName,Position")] EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }

        // GET: Employee/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("Not Found");
            }

            var model = new EmployeeVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Position = user.Position,
                PhoneNumber = user.PhoneNumber,
            };
            return View(model);
            /*if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);*/
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeVM model)                
        {
           var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("Not Found");
            }
            else
            {
                user.Id = model.Id;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Position = model.Position;
                user.PhoneNumber = model.PhoneNumber;
                //_context.Update(model);
                //await _context.SaveChangesAsync();

                 await _userManager.UpdateAsync(user);

            }  
            TempData["msg"] = "Profile Changes Saved !";
            return RedirectToAction("Index");
        
        /* if (id != model.Id)
         {
             return NotFound();
         }

         if (ModelState.IsValid)
         {
             try
             {
                 _context.Update(model);
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!EmployeeVMExists(model.Id))
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
         return View(model);*/
    }

        // GET: Employee/Delete/5
        public async Task <ActionResult> Delete(string id)
        {
            /*if (id == null)
            {
                return BadRequest();
            }
            var user = _userManager.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return BadRequest();
            }
            return View(user);*/
            if (id == null)
            {
                return NotFound();
            }

            var employeeVM = await _userManager.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeVM == null)
            {
                return NotFound();
            }

            return View(employeeVM);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {


            var user = await _userManager.FindByIdAsync(id);

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                TempData["UserDeleted"] = "User Successfully Deleted";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UserDeleted"] = "Error Deleting User";
                return RedirectToAction("Index");
            }
        }

     }

                /*var employeeVM = await _context.EmployeeVM.FindAsync(id);
                _context.EmployeeVM.Remove(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));*/
            

        /*private bool EmployeeVMExists(string id)
        {
            return _userManager.User(e => e.Id == id);
        }*/
 }

