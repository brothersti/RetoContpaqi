namespace Reto.Contpaqi.Web.Models
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
                lst = _appDbContext.Employees.ToList();

                if (lst.Any())
                    return lst;

                return lst;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Create(Employee employee)
        {
            try
            {                
                _appDbContext.Employees.Add(employee);

                _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            var result = new Employee();
            result = _appDbContext.Employees.FirstOrDefault(e => e.EmpleadoId == id);

            if (result != null)
                return result;

            return result;
        }

        public Employee GetEmployee(string filter)
        {
            throw new NotImplementedException();
        }

        public Employee Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
