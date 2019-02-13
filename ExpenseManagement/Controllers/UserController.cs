    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using ExpenseManagement.Data;
    using ExpenseManagement.Models;
    using ExpenseManagement.Service;
    using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;


    namespace ExpenseManagement.Controllers
    {
        public class UserController : Controller{
            private readonly IUserService userService;

            public UserController(IUserService userService){
                    this.userService = userService;
                }


                    [HttpGet]
                    public IActionResult Signup()
                    {
                        var signupVM = new UserSignupVM();
                        return View(signupVM);
                    }





                    [HttpPost]
                    public IActionResult Signup(UserSignupVM formData){
                        if (!ModelState.IsValid){
                            return View(formData);
                        }

                    try {
                         var result = userService.CreateUser(formData);
                        if (result.IsFaulted)
                        {
                            return View(formData);
                        }
                    }
                     catch (Exception ex){
                        Console.WriteLine(ex.Message);
                        }
                            return RedirectToAction(nameof(Login));
                    }



                    [HttpGet]
                    public IActionResult Login(){
                        var loginVM = new UserLoginVM();
                        return View(loginVM);
                    }


                    [HttpPost]
                    public async Task<IActionResult> Login(UserLoginVM userLoginVM){
                        if (!ModelState.IsValid){
                            return View(userLoginVM);
                        }
                    try{
                User user = new User
                {
                    Email = userLoginVM.Email,
                    Password = userLoginVM.Password
                };

                //await userService.LoginUser(userLoginVM);
                        var identity = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.Name, user.Email),
                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    }
                    catch (Exception)
                    {
                        throw;
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
