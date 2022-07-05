﻿using Microsoft.AspNetCore.Mvc;
using Reto.Contpaqi.Web.Models;

namespace Reto.Contpaqi.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee request)
        {
            if (ModelState.IsValid)
            {
                //llamar a la api
                _employeeRepository.Create(request);

                return RedirectToAction("Index", "Home");
            }

            return View("Index");
        }               
    }
}
