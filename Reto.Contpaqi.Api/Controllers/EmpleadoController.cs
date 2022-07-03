using Microsoft.AspNetCore.Mvc;
using Reto.Contpaqi.Database;
using Reto.Contpaqi.Database.Models;

namespace Reto.Contpaqi.Api.Controllers
{
    /// <summary>
    /// Controlador empleado
    /// </summary>
    [Route("api/[Controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private RetoContpaqiContext _context;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="context">cadena de conexión</param>
        public EmpleadoController(RetoContpaqiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método encargado de obtener los empleados
        /// </summary>
        /// <returns>Empleados</returns>
        [HttpGet]
        public IEnumerable<Empleado> GetEmpleados() => _context.Empleados.ToList();

        /// <summary>
        /// Método encargado de buscar un empleado por filtro
        /// </summary>
        /// <param name="texto">Filtro</param>
        /// <returns>Empleado</returns>
        [HttpGet("texto")]
        public ActionResult<Empleado> BuscarEmpleado(string texto)
        {
            return Ok(_context.Empleados.Where(e => e.Nombre == texto.ToLower()
                                                || e.Email == texto.ToLower()
                                                || e.Puesto == texto.ToLower()
                                                || e.Rfc == texto.ToLower()
                                                || e.FechaAlta.ToString("d") == texto.ToLower())
                .FirstOrDefault());
        }
    }
}
