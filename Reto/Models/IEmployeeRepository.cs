namespace Reto.Contpaqi.Web.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> AllEmployees();
        Employee GetById(int id);
        void Create(Employee employee);
        Employee Update(int id);
        bool Delete(int id);
        Employee GetEmployee(string filter);
    }
}
