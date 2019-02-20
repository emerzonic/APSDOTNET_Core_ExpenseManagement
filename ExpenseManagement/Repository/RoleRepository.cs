using System;
using System.Linq;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Repository
{
    public class RoleRepository: IRoleRepository
    {
        private ExpenseMangtDbContext _context;

        public RoleRepository(ExpenseMangtDbContext context)
        {
            _context = context;
        }


        public IdentityRole GetRole(string roleName)
        {
          return _context.Roles.Single(r => r.Name == roleName);
        }
    }
}
