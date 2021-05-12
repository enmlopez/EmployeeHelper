using EmployeeHelper.Contracts;
using EmployeeHelper.Models.ShiftModels;
using EmployeeHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeHelper.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftServices service;

        public ShiftController(IShiftServices shiftServices)
        {
            service = shiftServices;
        }

        // GET: Shift
        public ActionResult Index()
        {
            IEnumerable<ShiftListItem> model = service.GetShift();
            return View(model);
        }

        //GET: Shift/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Shift/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ShiftCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (service.CreateShift(model))
            {
                TempData["SaveShiftResult"] = $"Shift {model.Shift} was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create new Shift");

            return View(model);
        }

        //GET: Shift/Details/{id}
        public ActionResult Details(int id)
        {
            ShiftDetail model = service.GetShiftById(id);
            return View(model);
        }

        //GET: Shift/Edit/{id}
        public ActionResult Edit(int id)
        {
            ShiftDetail detail = service.GetShiftById(id);
            ShiftEdit model = new ShiftEdit
            {
                ShiftId = detail.ShiftId,
                Shift = detail.Shift
                //Should I add employee here?
            };
            return View(model);
        }

        //POST: Shift/Edit{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShiftEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.ShiftId != id)
            {
                ModelState.AddModelError("", "ID does not match.");
                return View(model);
            }
            if (service.UpdateShift(model))
            {
                TempData["SaveShiftResult"] = $"Shift {service.GetShiftById(id).Shift} was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Shift could not be updated.");
            return View();
        }

        //GET:Shift/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            ShiftDetail model = service.GetShiftById(id);

            return View(model);
        }

        //POST:Shift/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteT(int id)
        {
            TempData["SaveShiftResult"] = $"Shift {service.GetShiftById(id).Shift} was deleted.";
            if (service.DeleteShift(id))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not delete Shift.");
            return View();
        }
    }
}