using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        //public List<IdentityRole> Roles { get; set; }

        public ApplicationUser()
        {
        //    Roles = new List<IdentityRole>();
        }

        //public async Task<ClaimsIdentity>
        //GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    var userIdentity = await manager
        //        .CreateIdentityAsync(this,
        //            DefaultAuthenticationTypes.ApplicationCookie);
        //    return userIdentity;
        //}

        //public void AddRole(IdentityRole role)
        //{
        //    Roles.Add(role);
        //}


    }
}
