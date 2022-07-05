namespace Reto.Contpaqi.Api.Models
{
    public interface IEmployeeRepository
    {
       Task<IEnumerable<Employee>> AllEmployees();
        Employee GetById(int id);
        bool Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);
        Task<Employee> GetEmployee(string filter, string opcion);
    }
}
