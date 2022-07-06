using Microsoft.AspNetCore.Mvc;
using Reto.Contpaqi.Web.Models;
using Reto.Contpaqi.Web.ViewModels;
using System.Text.Json;

namespace Reto.Contpaqi.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly HttpClient client = new();
        readonly string urlBase = "https://localhost:7297/api/Empleado/";

        public async Task<IActionResult> Index()
        {
            var homeViewModel = new HomeViewModel();

            var response = await client.GetAsync($"{urlBase}GetAllEmployees");
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<List<Employee>>(responseStream,
                                                                            new JsonSerializerOptions
                                                                            {
                                                                                IgnoreNullValues = true,
                                                                                PropertyNameCaseInsensitive = true
                                                                            });

            homeViewModel.Employees = responseObject;

            return View(homeViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{urlBase}GetEmployee?id={id}");
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var employee = await JsonSerializer.DeserializeAsync<Employee>(responseStream,
                                                                            new JsonSerializerOptions
                                                                            {
                                                                                IgnoreNullValues = true,
                                                                                PropertyNameCaseInsensitive = true
                                                                            });
            return View(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Details(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var postResponse = await client.PutAsJsonAsync($"{urlBase}ActualizarEmpleado", employee);

                postResponse.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Home");
            }

            return View(employee);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var postResponse = await client.DeleteAsync($"{urlBase}EliminarEmpleado?id={id}");

            postResponse.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchCompleted(Filtro filtro)
        {
            HttpResponseMessage response = await client.GetAsync($"{urlBase}BuscarEmpleado?texto={filtro.Texto}&opcion={filtro.Opcion}");
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var employee = await JsonSerializer.DeserializeAsync<List<Employee>>(responseStream,
                                                                            new JsonSerializerOptions
                                                                            {
                                                                                IgnoreNullValues = true,
                                                                                PropertyNameCaseInsensitive = true
                                                                            });
           
            return View("_SearchCompleted", employee);
        }
    }
}
