using DomainLayer.Models;

namespace ServiceLayer.Services.Interfaces
{
    public interface IEmployeeServices<T> where T : Employee
    {
        IEnumerable<T> GetAllEmployee();
        T GetEmployeeByID(int id);
        void AddEmployee(T employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(T employee);
 
    }

}
