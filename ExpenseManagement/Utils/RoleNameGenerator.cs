using System;
namespace ExpenseManagement.Utils
{
    public static class RoleNameGenerator
    {
        public static string GetRoleNameFromAccessCode(string accessCode)
        {
            string RoleName = "";
            switch (accessCode)
            {
                case "123":
                    RoleName = "ADMIN";
                    break;
                case "456":
                    RoleName = "MANAGER";
                    break;
                default:
                    RoleName = "EMPLOYEE";
                    break;
            }
            return RoleName;
        }
    }

}
