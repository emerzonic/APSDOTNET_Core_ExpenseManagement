using System;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Repository
{
    public interface IRoleRepository
    {
        IdentityRole GetRole(string roleName);
    }
}
