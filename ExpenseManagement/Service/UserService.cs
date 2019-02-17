using ExpenseManagement.Models;
using ExpenseManagement.Repository;
using ExpenseManagement.ViewModels;

namespace ExpenseManagement.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(
            IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public ApplicationUser BuildNewUser(UserSignupVM formData)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = formData.Email,
                Email = formData.Email,
                FirstName = formData.FirstName,
                LastName = formData.LastName
            };
            Role role = new Role(formData.AccessCode);
            user.AddRole(role);
            return user;
        }


        public ApplicationUser GetUser(string email)
        {
          return userRepository.GetUserByUsername(email);
        }
    }
}
