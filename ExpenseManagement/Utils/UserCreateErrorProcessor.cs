using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Utils
{
    public static class UserCreateErrorProcessor
    {
      private static string GetErrorKey(IdentityResult result)
        {
            var errorKey = "";
            var errorCode = result.Errors.First().Code;
            if (Regex.IsMatch(errorCode, @"\Email\"))
            {
                errorKey = "Email";
            }
            if ((Regex.IsMatch(errorCode, @"\Password\")))
            {
                errorKey = "Password";
            }

            return errorKey;
        }

        private static string GetErrorMessage(IdentityResult result)
        {
            return result.Errors.First().Description;
        }
    }
}
