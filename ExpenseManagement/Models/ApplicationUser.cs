using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private List<Role> Roles;

        public ApplicationUser()
        {
            Roles = new List<Role>();
        }

        public List<Role> GetRoles()
        {
            return Roles;
        }

        public void AddRole(Role role)
        {
            Roles.Add(role);
        }

    }
}
