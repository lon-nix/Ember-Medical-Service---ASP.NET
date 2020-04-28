using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ember_Medical_Service.Contracts;
using Ember_Medical_Service.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ember_Medical_Service.Controllers
{
    [Authorize (Roles ="Administrator")]

    public class PositionController : Controller
    {
        private readonly IPositionRepository _Positionrepo;
        private readonly IMapper _Dbmapper;

        public PositionController(IPositionRepository Positionrepo, IMapper Dbmapper)
        {
            _Positionrepo = Positionrepo;
            _Dbmapper = Dbmapper;


        }
        // GET: Position
        public ActionResult Index()
        {
            var PositionList = _Positionrepo.FindAll();
            var PositionMapper = _Dbmapper.Map<ICollection<Position>, ICollection<ListOfPositionsVM>>(PositionList);
            return View(PositionMapper);
        }

        // GET: Position/Details/5
        public ActionResult Details(int id)
        {
            if (!_Positionrepo.IsExist(id))
            {

                return NotFound();
            }
            var position = _Positionrepo.FindByID(id);
            var PositionDetails = _Dbmapper.Map<ListOfPositionsVM>(position);

            return View(PositionDetails);
            
        }

        // GET: Position/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Position/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePositionVM position)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(position);
                }
                var Createposition = _Dbmapper.Map<Position>(position);

                //Position.CreatedDate = DateTime.Now; 

                var successful = _Positionrepo.Create(Createposition);

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

        // GET: Position/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_Positionrepo.IsExist(id))
            {
                
                return NotFound();
            }
            var position = _Positionrepo.FindByID(id);
            var PositionUpdate = _Dbmapper.Map<ListOfPositionsVM>(position);

            return View(PositionUpdate);
        }

        // POST: Position/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ListOfPositionsVM position)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(position);
                }
                var Editposition = _Dbmapper.Map<Position>(position);
                var successful = _Positionrepo.Update(Editposition);

                if (!successful)
                {
                    ModelState.AddModelError("", "Error processing request");
                    return View(position);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Error processing request");
                return View(position);
            }
        }

        // GET: Position/Delete/5
        public ActionResult Delete(int id)
        {
            var title = _Positionrepo.FindByID(id);
            if (title == null)
            {
                return NotFound();
            }
            var successful = _Positionrepo.Delete(title);

            if (!successful)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Position/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ListOfPositionsVM position)
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