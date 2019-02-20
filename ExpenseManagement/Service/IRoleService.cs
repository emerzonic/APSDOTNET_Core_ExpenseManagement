using System;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Service
{
    public interface IRoleService
    {
        IdentityRole GetRole(string roleName);
    }
}
