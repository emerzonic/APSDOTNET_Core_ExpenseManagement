using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.ViewModels
{
    public class EmployeeSignupVM : EmployeeLoginVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string AccessCode { get; set; }

        public EmployeeSignupVM(){}

        public string SetEmployeeRole()
        {
            return AccessCode == "123" ? "ADMIN" : "Employee";
        }
    }
}
