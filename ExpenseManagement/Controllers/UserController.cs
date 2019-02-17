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
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ExpenseManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private ExpenseMangtDbContext context;
        private UserManager<ApplicationUser> manager;

        public UserController(IUserService userService,
        ExpenseMangtDbContext context,
        UserManager<ApplicationUser> manager)
        {
            this.userService = userService;
            this.context = context;
            this.manager = manager;
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
                var result = await manager.CreateAsync(user, formData.Password);
                if (!result.Succeeded)
                {
                    //foreach (var error in result.Errors)
                    //{
                    ModelState.AddModelError("Email", DbError.GetErrorText(result));
                    //}
                    return View(formData);
                }
                context.Add(user);
                context.SaveChanges();
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
                //ApplicationUser user = new ApplicationUser();
                ApplicationUser user = userService.GetUser(userLoginVM.Email);
                //user.Email = user1.Email;
                //var result = await signInManager.PasswordSignInAsync(user.Email,
                //userLoginVM.Password, user.EmailConfirmed, lockoutOnFailure: false);
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    //new Claim(ClaimTypes.Role, user.Role.Name),
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
