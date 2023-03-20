using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class Repository <T>   : IRepository<T> where T : Employee
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private DbSet<T> employees;
        public Repository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
            employees = _employeeDbContext.Set<T>();

        }
        public IEnumerable<T> GetAllEmployee()
        {
            return employees.AsEnumerable();
        }
        public T GetEmployeeByID(int id)
        {
            return employees.SingleOrDefault(e=e=>e.Id == id);
        }

        public void AddEmployee(T employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("employee");
            }
            employees.Add(employee);
            _employeeDbContext.SaveChanges();
        }
        public void DeleteEmployee(T employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("employee");
            }
            employees.Remove(employee);
            _employeeDbContext.SaveChanges();
        }
        public void UpdateEmployee(T employee) { 
            if (employee == null) 
            {
                throw new ArgumentNullException("employee");
            } 
            employees.Update(employee);
            _employeeDbContext.SaveChanges();
        }
        public void SaveChanges()
        {
            _employeeDbContext.SaveChanges();
        }

    }
}
