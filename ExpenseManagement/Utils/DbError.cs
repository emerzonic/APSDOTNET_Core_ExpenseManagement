using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Utils
{
    public static class DbError
    {
        public static string GetErrorText(IdentityResult result)
        {
            string text = null;
            foreach (var error in result.Errors)
                text = error.Description;
            return text;
        }

    }
}
