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
        public string AccessCode { get; set; }

        public UserSignupVM(){}
    }
}
