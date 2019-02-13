//using System;
//using ExpenseManagement.Models;
//using Microsoft.AspNetCore.Identity;

//namespace ExpenseManagement.Data
//{
//    public class CustomUserManager: UserManager<ApplicationUser>
//    {
//        public CustomUserManager(IUserStore<ApplicationUser> store) : base(store)
//        {
//        }

//        public virtual CustomUserManager Create(IdentityFactoryOptions<CustomUserManager> options, ExpenseMangtDbContext context)
//        {
//            ExpenseMangtDbContext db = context.GetType();
//        }
//    }
//}
