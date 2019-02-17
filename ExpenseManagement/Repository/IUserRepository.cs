using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Repository
{
    public interface IUserRepository
    {
         ApplicationUser GetUser(string email);
        //Task<IActionResult>  CreateUser(User user, string password);
        //Task<IActionResult> LoginUserAsync(ApplicationUser user);
    }
}
