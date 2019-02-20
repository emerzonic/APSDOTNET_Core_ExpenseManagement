using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private ExpenseMangtDbContext context;

        public UserRepository(ExpenseMangtDbContext dbContext)
        {
            context = dbContext;
        }


        public ApplicationUser GetUserByUsername(string email)
        {
            return context.Users
                 //.Include(u => u)
                 .Single(u => u.Email == email);
        }
    }
}
