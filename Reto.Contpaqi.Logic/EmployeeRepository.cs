using Reto.Contpaqi.Database;
using Reto.Contpaqi.Database.Models;

namespace Reto.Contpaqi.Logic
{
    public class EmployeeRepository
    {
        private readonly RetoContpaqiContext _context;

        public EmployeeRepository() { }
        public EmployeeRepository(RetoContpaqiContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmpleados() => _context.Empleados;
        public Employee GetEmployeeById(int id)=> _context.Empleados.FirstOrDefault(e => e.EmpleadoId == id);

        public Employee ObtenerEmpleado(string filtro)
        {
            return _context.Empleados.Where(e => e.Nombre == filtro.ToLower()
                                                || e.Email == filtro.ToLower()
                                                || e.Puesto == filtro.ToLower()
                                                || e.Rfc == filtro.ToLower()
                                                || e.FechaAlta.ToString("d") == filtro.ToLower())
                .FirstOrDefault();
        }

        //public Employee CrearEmpleado(Employee request)
        //{

        //}

        //public Employee ActualizarEmpleado(int id)
        //{

        //}

        //public bool EliminarEmpleado(int id)
        //{

        //}
    }
}