    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    namespace ExpenseManagement.Models
    {
        public class User: ApplicationUser
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public Role Role { get; set; }

            public User() { }

        public void AddRole(Role role)
        {
            this.Role = role;
        }

    }
    }
