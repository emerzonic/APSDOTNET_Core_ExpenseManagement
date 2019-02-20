using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using ExpenseManagement.Service;
using ExpenseManagement.Utils;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly ExpenseMangtDbContext context;
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
            this.userService = userService;
            this.context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
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
                    ModelState.AddModelError("Email", userResult.Errors.First().Description);
                    return View(formData);
                }

                var roleName = RoleNameGenerator.GetRoleNameFromAccessCode(formData.AccessCode);
                bool roleExistResult = await _roleManager.RoleExistsAsync(roleName);
                IdentityRole role;

                if (!roleExistResult)
                {
                    role = new IdentityRole(roleName);
                    var roleResult = await _roleManager.CreateAsync(role);
                }
                else
                {
                    role = await _roleManager.FindByNameAsync(roleName);
                }

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
                ApplicationUser user = userService.GetUser(userLoginVM.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "Invalid username and or password.");
                    return View(userLoginVM);
                }

                await _userManager.AddClaimAsync(user, new Claim("FirstName", user.FirstName));
                //var claims = User.Claims;
                //await user.

                //var identity = new ClaimsIdentity(new[]
                //{
                //    new Claim(ClaimTypes.Name, user.FirstName),
                //    //new Claim(ClaimTypes., user.Id),

                //    }, CookieAuthenticationDefaults.AuthenticationScheme);

                //var principal = new ClaimsPrincipal(identity);
                var signInResult = await _signInManager.PasswordSignInAsync(user, userLoginVM.Password, false, false);
                if (!signInResult.Succeeded)
                {
                    ModelState.AddModelError("Email", "Invalid username and/or password.");
                    return View(userLoginVM);
                }

                //var ssre = await HttpContext.AuthenticateAsync(); //SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

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
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
