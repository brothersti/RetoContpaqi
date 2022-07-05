﻿namespace Reto.Contpaqi.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Employee>> AllEmployees()
        {
            try
            {
                var lst = new List<Employee>();

                await Task.Run(() =>
                {
                    lst = _appDbContext.Employees.ToList();
                });

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

                _appDbContext.SaveChanges();
                return true;
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

            if (result != null)
                return result;

            return result;
        }

        /// <summary>
        /// Método encargado de obtener un empleado mediante un filtro
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployee(string filter, string opcion)
        {
            var lst = new Employee();

            switch (opcion)
            {
                case "Nombre":
                    await Task.Run(() =>
                     {
                         lst = _appDbContext.Employees.FirstOrDefault(e => e.Nombre == filter);
                     });
                    break;

                case "Rfc":
                    await Task.Run(() =>
                    {
                        lst = _appDbContext.Employees.FirstOrDefault(e => e.Rfc == filter);
                    });
                    break;

                case "Alta":
                    await Task.Run(() =>
                    {
                        lst = _appDbContext.Employees.FirstOrDefault(e => e.EstatusEmpleado == 1);
                    });
                    break;

                case "Baja":
                    await Task.Run(() =>
                    {
                        lst = _appDbContext.Employees.FirstOrDefault(e => e.EstatusEmpleado == 0);
                    });
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

                _appDbContext.SaveChanges();

                return true;
            }
            return false;
        }
    }
}