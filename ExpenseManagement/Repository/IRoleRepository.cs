using System;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Repository
{
    public interface IRoleRepository
    {
        void CreateRole(string roleName);
        IdentityRole GetRole(string roleName);
    }
}
