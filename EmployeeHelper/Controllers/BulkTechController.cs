using EmployeeHelper.Models.BTModels;
using EmployeeHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeHelper.Controllers
{
    public class BulkTechController : Controller
    {
        // GET: BulkTech
        public ActionResult Index()
        {
            BTServices service = new BTServices();
            IEnumerable<BTListItem> model = service.GetBT();
            return View(model);
        }

        //GET: BulkTech/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: BulkTech/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(BTCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            BTServices service = new BTServices();
            if (service.BTCreate(model))
            {
                TempData["SaveBTResult"] = $"Bulk/Tech Sample {model.DueOnDate.ToLongDateString()} was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create Bulk/Tech Sample Date.");

            return View(model);
        }

        //GET: BulkTech/Details/{id}
        public ActionResult Details(int id)
        {
            BTServices service = new BTServices();
            BTDetail model = service.GetBTById(id);
            return View(model);
        }

        //GET: BulkTech/Edit/{id}
        public ActionResult Edit(int id)
        {
            BTServices service = new BTServices();
            BTDetail detail = service.GetBTById(id);
            BTEdit model = new BTEdit
            {
                BTId = detail.BTId,
                IsComplete = detail.IsComplete,
                DueOnDate = detail.DueOnDate,
                //CompletedOnDate = detail.CompletedOnDate
                //Should I add employee here?
            };
            return View(model);
        }

        //POST: BulkTech/Edit{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BTEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.BTId != id)
            {
                ModelState.AddModelError("", "ID does not match.");
                return View(model);
            }
            BTServices service = new BTServices();
            if (service.UpdateBT(model))
            {
                TempData["SaveBTResult"] = $"Bulk/Tech Sample {service.GetBTById(id).DueOnDate.ToLongDateString()} was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Bulk/Tech Sample date could not be updated.");
            return View();
        }

        //GET:BulkTech/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            BTServices service = new BTServices();
            BTDetail model = service.GetBTById(id);

            return View(model);
        }

        //POST:BulkTech/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBT(int id)
        {
            BTServices service = new BTServices();
            TempData["SaveBTResult"] = $"Bulk/Tech Sample {service.GetBTById(id).DueOnDate.ToLongDateString()} was updated.";
            if (service.DeleteBT(id))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not delete Bulk/Tech sample date.");
            return View();
        }


        ///TEST

        //GET: BulkTech/CompletedBy/{id}
        public ActionResult CompletedBy(int id)
        {
            BTServices service = new BTServices();
            BTDetail detail = service.GetBTById(id);
            BTEdit model = new BTEdit
            {
                BTId = detail.BTId,
                IsComplete = detail.IsComplete,
                DueOnDate = detail.DueOnDate,
                CompletedOnDate = detail.CompletedOnDate
                //Should I add employee here?
            };
            return View(model);
        }

        //POST: BulkTech/CompletedBy{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompletedBy(int id, BTEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.BTId != id)
            {
                ModelState.AddModelError("", "ID does not match.");
                return View(model);
            }
            BTServices service = new BTServices();
            if (service.UpdateBTCompletedBy(model))
            {
                TempData["SaveBTResult"] = $"Bulk/Tech Sample {service.GetBTById(id).DueOnDate.ToLongDateString()} was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Bulk/Tech Sample date could not be updated.");
            return View();
        }

    }
}