using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Models
{
    public class Role: IdentityRole
    {
        public Role(string name){
            Name = SetUserRole(name);
    }

        public string SetUserRole(string accessCode)
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
