using EmployeeHelper.Models.OTModels;
using EmployeeHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeHelper.Controllers
{
    public class OverTimeController : Controller
    {
        // GET: OverTime
        public ActionResult Index()
        {
            OverTimeServices service = new OverTimeServices();
            IEnumerable<OverTimeListItem> model = service.GetOT();
            return View(model);
        }

        //GET: OverTime/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: OverTime/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OverTimeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            OverTimeServices service = new OverTimeServices();
            if (service.OTCreate(model))
            {
                TempData["SaveOTResult"] = $"OverTime {model.OTDay} created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create OverTime date.");

            return View(model);
        }

        //GET: OverTime/Details
        public ActionResult Details(int id)
        {
            OverTimeServices service = new OverTimeServices();
            OverTimeDetail model = service.GetOTById(id);
            return View(model);
        }

        //GET: OverTime/Edit/{id}
        public ActionResult Edit(int id)
        {
            OverTimeServices service = new OverTimeServices();
            OverTimeDetail detail = service.GetOTById(id);
            OverTimeEdit model = new OverTimeEdit
            {
                OTId = detail.OTId,
                IsAvailable = detail.IsAvailable,
                OTDay = detail.OTDay,
                HoursWorked = detail.HoursWorked
            };
            return View(model);
        }

        //POST: OverTime/Edit{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OverTimeEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.OTId != id)
            {
                ModelState.AddModelError("", "ID does not match.");
                return View(model);
            }

            OverTimeServices service = new OverTimeServices();

            if (service.UpdateOverTime(model))
            {
                TempData["SaveOTResult"] = $"OverTime {model.OTDay} was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "OverTime could not be updated.");
            return View();
        }

        //GET: OverTime/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            OverTimeServices service = new OverTimeServices();
            OverTimeDetail model = service.GetOTById(id);

            return View(model);
        }

        //POST: OverTime/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOT(int id)
        {
            OverTimeServices service = new OverTimeServices();
            service.DeleteOverTime(id);
            TempData["SaveOTResult"] = $"OverTime {id} was removed.";

            return RedirectToAction("Index");
        }
    }
}