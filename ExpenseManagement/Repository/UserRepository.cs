using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Repository
{
    public class UserRepository:IUserRepository
    {
        private ExpenseMangtDbContext context;
        private UserManager<ApplicationUser> manager;

        public UserRepository(
            ExpenseMangtDbContext dbContext,
            UserManager<ApplicationUser> userManager)
        {
            context = dbContext;
            manager = userManager;
        }

        public async Task<IdentityResult> CreateUser(User user, string password)
        {
            var result = await manager.CreateAsync(user, password);
            context.Users.Add(user);
            context.SaveChanges();
            if (!result.Succeeded)
            {
                return null;
            }

            return result;
        }


        async Task<IActionResult> IUserRepository.LoginUserAsync(User user)
        {
            throw new NotImplementedException();

            //var identity = new ClaimsIdentity(new[]
            //             {
            //            new Claim(ClaimTypes.Name, user.Email),
            //            }, CookieAuthenticationDefaults.AuthenticationScheme);

            //var principal = new ClaimsPrincipal(identity);

            //return await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }



        public Task<IAsyncResult> GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
