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

        private EmployeeService CreateEmployeeService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            EmployeeService service = new EmployeeService(userId);
            return service;
        }
    }
}