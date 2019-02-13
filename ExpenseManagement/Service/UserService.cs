using System;
using System.Threading.Tasks;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using ExpenseManagement.Repository;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(
            IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }



        public Task<IdentityResult> CreateUser(UserSignupVM formData)
        {
            User user = new User{
                    UserName = formData.Email,
                    FirstName = formData.FirstName,
                    LastName = formData.LastName
                };
                Role userRole = new Role(formData.AccessCode);
                user.AddRole(userRole);
               return userRepository.CreateUser(user, formData.Password); 
        }


        public Task<IActionResult> LoginUser(UserLoginVM loginVM)
        {
            User user = new User
            {
                Email = loginVM.Email,
                Password = loginVM.Password
            };
            return userRepository.LoginUserAsync(user);
        }


        public Task<IActionResult> GetUser(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
