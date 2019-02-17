using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Models
{
    public class Role: IdentityRole
    {
        public Role(string name)
        {
            Name = SetRoleName(name);
        }

        private string SetRoleName(string accessCode)
        {
            string userRole = "";
            switch (accessCode)
            {
                case "123":
                    userRole = "ADMIN";
                    break;
                case "456":
                    userRole = "MANAGER";
                    break;
                default:
                    userRole = "EMPLOYEE";
                    break;
            }
            return userRole;
        }
    }
}
