namespace Reto.Contpaqi.Web.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> AllEmployees();
        Employee GetById(int id);
        void Create(Employee employee);
        void Update(Employee employee);
        bool Delete(int id);
        IEnumerable<Employee> GetEmployee(string filter, string opcion);
    }
}
