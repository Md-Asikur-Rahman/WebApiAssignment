using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;

namespace EmployeeListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeServices<Employee> _customEmployeeServices;
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeController(IEmployeeServices<Employee> customEmployeeServices, EmployeeDbContext employeeDbContext)
        {
            _customEmployeeServices= customEmployeeServices;
            _employeeDbContext= employeeDbContext;
        }
        [HttpGet(nameof(GetAllEmployee))]
        public IActionResult GetAllEmployee()
        {
            var employees = _customEmployeeServices.GetAllEmployee();
            if(employees!=null)
            {
                return Ok(employees);
            }
            else
            { 
                return BadRequest("Something wrong! Unable to get the EmployeeList");
            }
        }

        // [HttpGet(nameof(GetEmployeeByID))]
        [HttpGet("GetEmployeeByID/{id}")]
        public IActionResult GetEmployeeByID(int id)
        {
            var employee = _customEmployeeServices.GetEmployeeByID(id);
            if (employee!=null)
            {
                return Ok(employee);
            }
            else
            {
                return BadRequest("Something wrong! Unable to get the Employee");
            }
        }
       
        [HttpPost(nameof(AddNewEmployee))]        
        public IActionResult AddNewEmployee(Employee employee)
        {            
            if (employee!=null)
            {
                _customEmployeeServices.AddEmployee(employee);
                return Ok(employee);
               // return Ok("successfull");
            }
            else
            {
                return BadRequest("Something wrong! Unable to Add a New Employee");
            }
        }
       
        [HttpPost(nameof(UpdateEmployee))]
        public IActionResult UpdateEmployee(Employee employee)
        {
            if (employee!=null)
            {
                _customEmployeeServices.UpdateEmployee(employee);
                return Ok("Succesfully Employee Updated");
            }
            else
            {
                return BadRequest("Something wrong! Unable to Update the existing Employee");
            }
        }

        //[HttpDelete(nameof(DeleteEmployee))]
        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (id!=null)
            {
                _customEmployeeServices.DeleteEmployee(id);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something wrong!Unable to Delete the existing Employee");
            }
        }
    }
}
