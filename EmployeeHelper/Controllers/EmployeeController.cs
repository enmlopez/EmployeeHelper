using EmployeeHelper.Models.EmployeeModels;
using EmployeeHelper.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeHelper.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeService service = CreateEmployeeService();
            IEnumerable<EmployeeListItem> model = service.GetEmployees();

            return View(model);
        }

        //GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        //GET: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateEmployeeService();

            if (service.CreateEmployee(model))
            {
                TempData["SaveResult"] = "Employee successfully created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Employee could not be created");
            return View();
        }

        //GET: Employee/Details
        public ActionResult Details(int id)
        {
            EmployeeService service = CreateEmployeeService();
            EmployeeDetail model = service.GetEmployeeById(id);

            return View(model);
        }

        //GET: Employee/Edit
        public ActionResult Update(int id)
        {
            EmployeeService service = CreateEmployeeService();
            EmployeeDetail detail = service.GetEmployeeById(id);
            EmployeeEdit model = new EmployeeEdit
            {
                EmployeeId = detail.EmployeeId,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                HiringDate = detail.HiringDate,
                Shifts = detail.Shifts
            };

            return View(model);
        }

        //POST: Employee/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, EmployeeEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.EmployeeId != id)
            {
                ModelState.AddModelError("", "ID does not match");
                return View(model);
            }

            EmployeeService service = CreateEmployeeService();
            if (service.UpdateEmployee(model))
            {
                TempData["SaveResult"] = "Your employee was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your employee could not be updated.");
            return View();
        }

        private EmployeeService CreateEmployeeService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            EmployeeService service = new EmployeeService(userId);
            return service;
        }
    }
}