using EmployeeHelper.Models.TModels;
using EmployeeHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeHelper.Controllers
{
    public class TamcTymcController : Controller
    {
        // GET: TamcTymc
        public ActionResult Index()
        {
            TServices service = new TServices();
            IEnumerable<TListItem> model = service.GetT();
            return View(model);
        }

        //GET: TamcTymc/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: TamcTymc/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(TCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            TServices service = new TServices();
            if (service.TCreate(model))
            {
                TempData["SaveTResult"] = $"Tamc/Tymc Sample {model.DueOnDate.ToLongDateString()} was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create Bulk/Tech Sample Date.");

            return View(model);
        }

        //GET: TamcTymc/Details/{id}
        public ActionResult Details(int id)
        {
            TServices service = new TServices();
            TDetail model = service.GetTById(id);
            return View(model);
        }

        //GET: TamcTymc/Edit/{id}
        public ActionResult Edit(int id)
        {
            TServices service = new TServices();
            TDetail detail = service.GetTById(id);
            TEdit model = new TEdit
            {
                TId = detail.TId,
                IsComplete = detail.IsComplete,
                DueOnDate = detail.DueOnDate,
                //CompletedOnDate = detail.CompletedOnDate
                //Should I add employee here?
            };
            return View(model);
        }

        //POST: TamcTymc/Edit{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.TId != id)
            {
                ModelState.AddModelError("", "ID does not match.");
                return View(model);
            }
            TServices service = new TServices();
            if (service.UpdateT(model))
            {
                TempData["SaveTResult"] = $"Tamc/Tymc Sample {service.GetTById(id).DueOnDate.ToLongDateString()} was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Tamc/Tymc Sample date could not be updated.");
            return View();
        }

        //GET:TamcTymc/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            TServices service = new TServices();
            TDetail model = service.GetTById(id);

            return View(model);
        }

        //POST:TamcTymc/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteT(int id)
        {
            TServices service = new TServices();
            TempData["SaveTResult"] = $"Tamc/Tymc Sample {service.GetTById(id).DueOnDate.ToLongDateString()} was updated.";
            if (service.DeleteT(id))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not delete Tamc/Tymc sample date.");
            return View();
        }


        ///TEST

        //GET: TamcTymc/CompletedBy/{id}
        public ActionResult CompletedBy(int id)
        {
            TServices service = new TServices();
            TDetail detail = service.GetTById(id);
            TEdit model = new TEdit
            {
                TId = detail.TId,
                IsComplete = detail.IsComplete,
                DueOnDate = detail.DueOnDate,
                CompletedOnDate = detail.CompletedOnDate
                //Should I add employee here?
            };
            return View(model);
        }

        //POST: TamcTymc/CompletedBy{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompletedBy(int id, TEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.TId != id)
            {
                ModelState.AddModelError("", "ID does not match.");
                return View(model);
            }
            TServices service = new TServices();
            if (service.UpdateTCompletedBy(model))
            {
                TempData["SaveTResult"] = $"Tamc/Tymc Sample {service.GetTById(id).DueOnDate.ToLongDateString()} was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Tamc/Tymc Sample date could not be updated.");
            return View();
        }

    }
}