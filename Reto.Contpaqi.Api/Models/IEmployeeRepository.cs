namespace Reto.Contpaqi.Api.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> AllEmployees();
        Employee GetById(int id);
        bool Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);
        IEnumerable<Employee> GetEmployee(string filter, string opcion);
    }
}
