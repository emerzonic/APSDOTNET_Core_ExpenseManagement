using System;
using System.Linq;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Repository
{
    public class RoleRepository: IRoleRepository
    {
        private ExpenseMangtDbContext context;
        //private RoleManager<Role> manager;


        public RoleRepository(ExpenseMangtDbContext context
        //RoleManager<Role> manager
        )
        {
            this.context = context;
            //this.manager = manager;
        }

        public void CreateRole(string roleName)
        {
            //bool roleExist = manager.RoleExistsAsync(roleName)
            //manager.CreateAsync(roleName);
        }

        public IdentityRole GetRole(string roleName)
        {
          return context.Roles.Single(r => r.Name == roleName);
        }
    }
}
