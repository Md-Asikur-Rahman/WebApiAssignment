using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IRepository<T> where T : Employee
    {
        IEnumerable<T> GetAllEmployee();
        T GetEmployeeByID(int id);
        void AddEmployee(T employee);
        void DeleteEmployee(T employee);
        void UpdateEmployee(T employee);

        void SaveChanges();



    }
}
