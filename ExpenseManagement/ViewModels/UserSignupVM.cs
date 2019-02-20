using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.ViewModels
{
    public class UserSignupVM : UserLoginVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Compare("Password", ErrorMessage ="Confirm password doesn't match password!")]
        public string ConfirmPassword { get; set; }
        public string AccessCode { get; set; }

        public UserSignupVM(){}
    }
}
