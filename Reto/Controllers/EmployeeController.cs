using Microsoft.AspNetCore.Mvc;
using Reto.Contpaqi.Web.Models;

namespace Reto.Contpaqi.Web.Controllers
{
    public class EmployeeController : Controller
    {
        readonly HttpClient client = new HttpClient();
        readonly string urlBase = "https://localhost:7297/api/Empleado/";

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
                HttpResponseMessage response =  client.PostAsJsonAsync($"{urlBase}AgregarEmpleado", request).Result;
                response.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Home");
            }

            return View("Index");
        }               
    }
}
