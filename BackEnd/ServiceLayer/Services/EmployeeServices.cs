using DomainLayer.Models;
using RepositoryLayer.Repository.Interfaces;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer.Services
{
    public class EmployeeServices : IEmployeeServices<Employee>
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeServices(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
                var employees = _employeeRepository.GetAll();
                if (employees == null)
                {
                    return null;
                }
                else
                {
                    return employees;
                }
            }
            catch (Exception ex )
            {
                throw new Exception("Error fetching all employee. " + ex.Message);
            }
        }
        public Employee GetEmployeeByID(int id)
        {
            try
            {
                var one_employee = _employeeRepository.GetByID(id);
                if (one_employee == null)
                {
                    return null;
                }
                else
                {
                    return one_employee;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching employee by id " + ex.Message);
            }

        }
        
        public void AddEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    _employeeRepository.Add(employee);                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Adding employee. " + ex.Message);
            }
        }
        
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    _employeeRepository.Update(employee);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updating employee. " + ex.Message);
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                if (id != null)
                {
                    _employeeRepository.DeleteByID(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting employee. " + ex.Message);
            }
        }
    }

}
