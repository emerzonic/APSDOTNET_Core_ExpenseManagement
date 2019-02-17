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
        ApplicationUser GetUserByUsername(string email);
    }
}
