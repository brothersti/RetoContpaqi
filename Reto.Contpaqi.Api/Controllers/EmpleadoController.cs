using Microsoft.AspNetCore.Mvc;
using Reto.Contpaqi.Api.Models;
using System.Net;

namespace Reto.Contpaqi.Api.Controllers
{
    /// <summary>
    /// Controlador empleado
    /// </summary>
    [Route("api/[Controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="employeeRepository">cadena de conexión</param>
        public EmpleadoController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Método encargado de obtener los empleados
        /// </summary>
        /// <returns>Empleados</returns>
        [HttpGet]
        public ActionResult GetEmpleados()
        {
            var response = _employeeRepository.AllEmployees();
            if (response == null) { return NoContent(); }

            return Ok(response);
        }

        /// <summary>
        /// Método encargado de buscar un empleado por filtro
        /// </summary>
        /// <param name="texto">Filtro</param>
        /// <returns>Empleado</returns>
        [HttpGet("texto")]
        public ActionResult BuscarEmpleado(string texto, string opcion)
        {
            if (string.IsNullOrEmpty(texto) && string.IsNullOrEmpty(opcion)) return BadRequest();

            var response = _employeeRepository.GetEmployee(texto, opcion);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Método encargado de Agregar un empleado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddEmployee(Employee request)
        {
            if (ModelState.IsValid)
            {
                var response = _employeeRepository.Create(request);

                if (response)
                    return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// Método encargado de actualizar un empleado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult UpdateEmployee(Employee request)
        {
            if (ModelState.IsValid)
            {
                var response = _employeeRepository.Update(request);
                if (response) return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// Método encargado de inactivar un empleado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult DeleteEmpployee(int id)
        {
            if (id <= 0) return BadRequest();
            var response =_employeeRepository.Delete(id);
            if(response) return Ok(response);
            return Conflict();
        }
    }
}
