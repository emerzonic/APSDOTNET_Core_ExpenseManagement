using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using ExpenseManagement.Service;
using ExpenseManagement.Utils;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private ExpenseMangtDbContext context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserController(
                            IUserService userService,
                            ExpenseMangtDbContext context,
                            UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager
                            )
        {
            this.userService = userService;
            this.context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }


        [HttpGet]
        public IActionResult Signup()
        {
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
             
                var user = userService.BuildNewUser(formData);
                var userResult = await _userManager.CreateAsync(user, formData.Password);
                if (!userResult.Succeeded)
                {
                    ModelState.AddModelError("Email", DbError.GetErrorText(userResult));
                    return View(formData);
                }

                var roleName = RoleNameGenerator.GetRoleNameFromAccessCode(formData.AccessCode);
                bool roleExist = await _roleManager.RoleExistsAsync(roleName);
                IdentityRole role = null;

                if (!roleExist)
                {
                    role = new IdentityRole(roleName);
                    var roleResult = await _roleManager.CreateAsync(role);
                }
                else
                {
                    role = await _roleManager.FindByNameAsync(roleName);
                }

                var addUserToRoleResult = await _userManager.AddToRoleAsync(user, role.Name);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(formData);
            }
            return RedirectToAction(nameof(Login));
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
                ApplicationUser user = userService.GetUser(userLoginVM.Email);
                if (user == null)
                {
                    ModelState.AddModelError("InvalidLogin", "Invalid username and/or password.");
                    return View(userLoginVM);
                }

                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    //new Claim(ClaimTypes.Role, user.Roles),

                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

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
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
