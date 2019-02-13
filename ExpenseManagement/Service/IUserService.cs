using System;
using System.Threading.Tasks;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Service
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUser(UserSignupVM signupVM);
        Task<IActionResult> GetUser(int id);
        Task<IActionResult> LoginUser(UserLoginVM loginVM);

    }
}
