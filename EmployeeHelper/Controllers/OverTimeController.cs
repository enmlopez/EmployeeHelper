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
        public ActionResult Create (OverTimeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            OverTimeServices service = new OverTimeServices();
            if (service.OTCreate(model))
            {
                TempData["SaveResult"] = $"OverTime {model.OTDay} created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create OverTime date.");

            return View(model);
        }


    }
}