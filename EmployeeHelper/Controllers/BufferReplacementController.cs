using EmployeeHelper.Models.BufferModels;
using EmployeeHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeHelper.Controllers
{
    public class BufferReplacementController : Controller
    {
        // GET: BufferReplacement
        public ActionResult Index()
        {
            BufferServices service = new BufferServices();
            IEnumerable<BufferListItem> model = service.GetBuffer();
            return View(model);
        }

        //GET: BufferReplacement/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: BufferReplacement/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(BufferCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            BufferServices service = new BufferServices();
            if (service.BufferCreate(model))
            {
                TempData["SaveBufferResult"] = $"Buffer Replacement Date {model.DueOnDate.ToLongDateString()} was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create Buffer Replacement Date.");

            return View(model);
        }

        //GET: BufferReplacement/Details/{id}
        public ActionResult Details(int id)
        {
            BufferServices service = new BufferServices();
            BufferDetail model = service.GetBufferById(id);
            return View(model);
        }

        //GET: BufferReplacement/Edit/{id}
        public ActionResult Edit(int id)
        {
            BufferServices service = new BufferServices();
            BufferDetail detail = service.GetBufferById(id);
            BufferEdit model = new BufferEdit
            {
                BufferId = detail.BufferId,
                IsComplete = detail.IsComplete,
                DueOnDate = detail.DueOnDate,
                //CompletedOnDate = detail.CompletedOnDate
                //Should I add employee here?
            };
            return View(model);
        }

        //POST: BufferReplacement/Edit{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BufferEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.BufferId != id)
            {
                ModelState.AddModelError("", "ID does not match.");
                return View(model);
            }
            BufferServices service = new BufferServices();
            if (service.UpdateBuffer(model))
            {
                TempData["SaveBTResult"] = $"Buffer Replacement Date {service.GetBufferById(id).DueOnDate.ToLongDateString()} was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Buffer Replacement date could not be updated.");
            return View();
        }

        //GET:BufferReplacement/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            BufferServices service = new BufferServices();
            BufferDetail model = service.GetBufferById(id);

            return View(model);
        }

        //POST:BufferReplacement/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBuffer(int id)
        {
            BufferServices service = new BufferServices();
            TempData["SaveBufferResult"] = $"Buffer Replacement Date {service.GetBufferById(id).DueOnDate.ToLongDateString()} was updated.";
            if (service.DeleteBuffer(id))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not delete Buffer Replacement date.");
            return View();
        }


        ///TEST

        //GET: BufferReplacement/CompletedBy/{id}
        public ActionResult CompletedBy(int id)
        {
            BufferServices service = new BufferServices();
            BufferDetail detail = service.GetBufferById(id);
            BufferEdit model = new BufferEdit
            {
                BufferId = detail.BufferId,
                IsComplete = detail.IsComplete,
                DueOnDate = detail.DueOnDate,
                CompletedOnDate = detail.CompletedOnDate
                //Should I add employee here?
            };
            return View(model);
        }

        //POST: BufferReplacement/CompletedBy{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompletedBy(int id, BufferEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.BufferId != id)
            {
                ModelState.AddModelError("", "ID does not match.");
                return View(model);
            }
            BufferServices service = new BufferServices();
            if (service.UpdateBufferCompletedBy(model))
            {
                TempData["SaveBufferResult"] = $"Buffer Replacement date {service.GetBufferById(id).DueOnDate.ToLongDateString()} was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Buffer Replacement date could not be updated.");
            return View();
        }

    }
}