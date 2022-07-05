using Microsoft.AspNetCore.Mvc;
using Reto.Contpaqi.Web.Models;
using Reto.Contpaqi.Web.ViewModels;

namespace Reto.Contpaqi.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeRepository)
        {
            _employeeRepository = employeRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                Employees = _employeeRepository.AllEmployees()
            };
            return View(homeViewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if(employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult Details(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(employee);
                return RedirectToAction("Details", new {id = employee.EmpleadoId});
            }

            return View(employee);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("Index", "Home");
            //var employee = _employeeRepository.GetById(id);
            //if (employee == null)
            //{
            //    return NotFound();
            //}

            //return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _employeeRepository.Delete(employee.EmpleadoId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCompleted(Filtro filtro)
        {
            var result= _employeeRepository.GetEmployee(filtro.Texto, filtro.Opcion);
            return View("_SearchCompleted", result);
        }
    }
}
