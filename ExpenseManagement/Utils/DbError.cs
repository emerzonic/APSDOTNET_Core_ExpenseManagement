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
            foreach (var e in result.Errors)
                    text = e.Description;
            return text;
        }

    }
}
