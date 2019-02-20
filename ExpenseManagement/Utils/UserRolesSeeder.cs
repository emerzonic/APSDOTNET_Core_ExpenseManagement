using System;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Utils
{
    public class UserRolesSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesSeeder(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void Seed()
        {
            string[] roles = { "Admin", "Manager", "Employee", "Supervisor" };
            foreach (var roleName in roles)
            {
                var userRole = await _roleManager.FindByNameAsync(roleName);
                if (userRole == null)
                {
                    var newRole = new IdentityRole(roleName);
                    await _roleManager.CreateAsync(newRole);
                }

            }
        }
    }
}
