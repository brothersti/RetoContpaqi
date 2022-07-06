namespace Reto.Contpaqi.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Employee> AllEmployees()
        {
            try
            {
                var lst = new List<Employee>();
                lst = _appDbContext.Employees.Where(e => e.EstatusEmpleado == 1).ToList();

                if (lst.Any())
                    return lst;

                return lst;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Create(Employee employee)
        {
            try
            {
                _appDbContext.Employees.Add(new Employee
                {
                    EstatusEmpleado = 1,
                    Nombre = employee.Nombre,
                    ApellidoMaterno = employee.ApellidoMaterno,
                    ApellidoPaterno = employee.ApellidoPaterno,
                    Edad = employee.Edad,
                    Email = employee.Email,
                    FechaNacimiento = employee.FechaNacimiento,
                    Rfc = employee.Rfc,
                    Puesto = employee.Puesto,
                    Telefono = employee.Telefono,
                    GeneroId = employee.GeneroId,
                    EstadoCivilId = employee.EstadoCivilId,
                    FechaAlta = employee.FechaAlta,
                    FechaBaja = employee.FechaBaja,
                    Direccion = new()
                    {
                        Calle = employee.Direccion.Calle,
                        NumeroExterior = employee.Direccion.NumeroExterior,
                        NumeroInterior = employee.Direccion.NumeroInterior,
                        CodigoPostal = employee.Direccion.CodigoPostal,
                        Estado = employee.Direccion.Estado,
                        Municipio = employee.Direccion.Municipio,
                        Pais = employee.Direccion.Pais
                    }


                });

                var result = _appDbContext.SaveChanges();

                if (result > -1) return true;
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var employeeSelected = _appDbContext.Employees.SingleOrDefault(e => e.EmpleadoId == id);

                employeeSelected.EstatusEmpleado = 0;
                employeeSelected.FechaBaja = DateTime.Now;

                var res = _appDbContext.Employees.Update(employeeSelected);
                _appDbContext.SaveChanges();

                return res != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee GetById(int id)
        {
            var result = new Employee();
            result = _appDbContext.Employees.FirstOrDefault(e => e.EmpleadoId == id);

            var direccion = _appDbContext.Direccion.FirstOrDefault(d => d.DireccionId == result.DireccionId);

            result.Direccion = new Direccion
            {
                Calle = direccion.Calle,
                Municipio = direccion.Municipio,
                NumeroExterior = direccion.NumeroExterior,
                NumeroInterior = direccion.NumeroInterior,
                Pais = direccion.Pais,
                CodigoPostal = direccion.CodigoPostal,
                Estado = direccion.Estado,
            };

            if (result != null)
                return result;

            return result;
        }

        public IEnumerable<Employee> GetEmployee(string filter, string opcion)
        {
            var lst = new List<Employee>();

            switch (opcion)
            {
                case "Nombre":
                    lst = _appDbContext.Employees.Where(e => e.Nombre == filter).ToList();
                    break;

                case "Rfc":
                    lst = _appDbContext.Employees.Where(e => e.Rfc == filter).ToList();
                    break;

                case "Alta":
                    lst = _appDbContext.Employees.Where(e => e.EstatusEmpleado == 1).ToList();
                    break;

                case "Baja":
                    lst = _appDbContext.Employees.Where(e => e.EstatusEmpleado == 0).ToList();
                    break;

                default:
                    break;
            }

            return lst;
        }

        public bool Update(Employee employee)
        {
            var existing = GetById(employee.EmpleadoId);
            if (existing != null)
            {
                existing.Email = employee.Email;
                existing.Telefono = employee.Telefono;
                existing.Puesto = employee.Puesto;
                existing.FechaBaja = employee.FechaBaja;
                existing.EstadoCivilId = employee.EstadoCivilId;
                existing.Direccion = new Direccion
                {
                    Calle = employee.Direccion.Calle,
                    NumeroExterior = employee.Direccion.NumeroExterior,
                    NumeroInterior = employee.Direccion.NumeroInterior,
                    CodigoPostal = employee.Direccion.CodigoPostal,
                    Estado = employee.Direccion.Estado,
                    Municipio = employee.Direccion.Municipio,
                    Pais = employee.Direccion.Pais
                };

                var result = _appDbContext.SaveChanges();
                if (result > -1) return true;
            }
            return false;
        }
    }
}
