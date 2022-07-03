using Microsoft.AspNetCore.Mvc;

namespace Reto.Contpaqi.Api.Controllers
{
    /// <summary>
    /// Controlador empleado
    /// </summary>
    [Route("api/[Controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private readonly EmployeeRepository empleadoLogic;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="context">cadena de conexión</param>
        public EmpleadoController()
        {
            empleadoLogic = new EmployeeRepository();
        }

        /// <summary>
        /// Método encargado de obtener los empleados
        /// </summary>
        /// <returns>Empleados</returns>
        [HttpGet]
        public IEnumerable<Employee> GetEmpleados() => empleadoLogic.GetAllEmpleados();

        /// <summary>
        /// Método encargado de buscar un empleado por filtro
        /// </summary>
        /// <param name="texto">Filtro</param>
        /// <returns>Empleado</returns>
        [HttpGet("texto")]
        public ActionResult<Employee> BuscarEmpleado(string texto)
        {
            return Ok(empleadoLogic.ObtenerEmpleado(texto));
        }
    }
}
