using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using ExpenseManagement.Service;
using ExpenseManagement.Utils;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ExpenseMangtDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(
                            IUserService userService,
                            ExpenseMangtDbContext context,
                            UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            SignInManager<ApplicationUser> signInManager
                            )
        {
            _userService = userService;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Signup()
        {
            new UserRolesSeeder(_roleManager).Seed();
            var signupVM = new UserSignupVM();
            return View(signupVM);
        }



        [HttpPost]
        public async Task<IActionResult> Signup(UserSignupVM formData)
        {

            if (!ModelState.IsValid)
            {
                return View(formData);
            }
            try
            {

                var user = _userService.BuildNewUser(formData);
                var userResult = await _userManager.CreateAsync(user, formData.Password);

                if (!userResult.Succeeded)
                {
                    ModelState.AddModelError("Email", userResult.Errors.First().Description);
                    return View(formData);
                }
                var roleName = RoleNameGenerator.GetRoleNameFromAccessCode(formData.AccessCode);
                var role = await _roleManager.FindByNameAsync(roleName);
                var addUserToRoleResult = await _userManager.AddToRoleAsync(user, role.Name);
                var signInResult = await _signInManager.PasswordSignInAsync(user, formData.Password, false, false);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(formData);
            }
            return Redirect("/Home/Welcome");
        }




        [HttpGet]
        public IActionResult Login()
        {
            var loginVM = new UserLoginVM();
            return View(loginVM);
        }




        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginVM);
            }

            try
            {
                string invalidLoginMessage = "Invalid username and or password.";
                var user = _userService.GetUser(userLoginVM.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", invalidLoginMessage);
                    return View(userLoginVM);
                }
                await _userManager.AddClaimAsync(user, new Claim("Id", user.Id));
                var signInResult = await _signInManager.PasswordSignInAsync(user, userLoginVM.Password, false, false);
                if (!signInResult.Succeeded)
                {
                    ModelState.AddModelError("Email", invalidLoginMessage);
                    return View(userLoginVM);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(userLoginVM);
            }

            return Redirect("/Home/Welcome");
        }



        [HttpGet]
        [Route("/user/logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
