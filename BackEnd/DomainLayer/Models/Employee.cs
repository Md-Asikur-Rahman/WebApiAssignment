using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Enter the employee's FirstName")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter the employee's LastName")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter the employee's Designation")]
        [DisplayName("Designation")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Enter the employee's Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Enter the employee's Email")]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter the employee's PhoneNumber")]
        //[Phone]
        [DisplayName("Phone")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Enter the employee's Description")]
        [DisplayName("About Me")]
        public string EmployeeDescription { get; set; }
        [Required(ErrorMessage = "Enter the employee's Picture")]
        [DisplayName("Upload Image")]
        public string EmployeePicuture { get; set; }

    }
}
