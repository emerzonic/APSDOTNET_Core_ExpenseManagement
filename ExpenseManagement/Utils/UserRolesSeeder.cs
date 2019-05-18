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
            string[] roles = { "ADMIN", "MANAGER", "EMPLOYEE", "SUPERVISOR" };
            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    IdentityRole newRole = new IdentityRole(roleName);
                    await _roleManager.CreateAsync(newRole);
                }

            }
        }
    }
}
