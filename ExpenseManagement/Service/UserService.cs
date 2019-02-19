using ExpenseManagement.Models;
using ExpenseManagement.Repository;
using ExpenseManagement.Utils;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleService roleService;

        public UserService(
            IUserRepository userRepository,
            IRoleService roleService)
        {
            this.userRepository = userRepository;
            this.roleService = roleService;
        }


        public ApplicationUser BuildNewUser(UserSignupVM formData)
        {
            return new ApplicationUser
            {
                UserName = formData.Email,
                Email = formData.Email,
                FirstName = formData.FirstName,
                LastName = formData.LastName,
            };
        }


        public ApplicationUser GetUser(string email)
        {
          return userRepository.GetUserByUsername(email);
        }
    }
}
