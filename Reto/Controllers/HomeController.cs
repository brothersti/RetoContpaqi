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
    }
}
