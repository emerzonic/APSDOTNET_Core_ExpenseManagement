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
        Task<IAsyncResult> GetUser(int id);
        Task<IdentityResult>  CreateUser(User user, string password);
        Task<IActionResult> LoginUserAsync(User user);
    }
}
