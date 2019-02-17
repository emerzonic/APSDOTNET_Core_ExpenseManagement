using System;
using System.Threading.Tasks;
using ExpenseManagement.Models;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Service
{
    public interface IUserService
    {
        ApplicationUser BuildNewUser(UserSignupVM signupVM);
        ApplicationUser GetUser(string email);
        //ApplicationUser GetCurrentUser();
        //Task<IActionResult> LoginUser(UserLoginVM loginVM);

    }
}
