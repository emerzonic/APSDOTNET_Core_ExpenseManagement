    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using ExpenseManagement.Data;
    using ExpenseManagement.Models;
    using ExpenseManagement.ViewModels;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


    namespace ExpenseManagement.Controllers
    {
        public class EmployeeController : Controller
            {
                private ExpenseMangtDbContext context;
        private UserManager<ApplicationUser> manager;
                public EmployeeController(ExpenseMangtDbContext dbContext,
                 UserManager<ApplicationUser> userManager)
                {
                    context = dbContext;
                    manager = userManager;
                }


                [HttpGet]
                public IActionResult Signup()
                {
                    var signupVM = new EmployeeSignupVM();
                    return View(signupVM);
                }



                [HttpPost]
                public async Task<IActionResult> Signup(EmployeeSignupVM formData)
                {
                    if (!ModelState.IsValid)
                    {
                        return View(formData);
                    }

                    try
                        {
                            var employee = new Employee
                            {   UserName = formData.Email,
                                FirstName = formData.FirstName,
                                LastName = formData.LastName,
                                Role = formData.SetEmployeeRole()
                            };
               
                            var result = await manager.CreateAsync(employee, formData.Password);
                //context.Add(employee);
                //context.SaveChanges();
               // if (result.Succeeded)
               // {
               //    bool test = true;
               //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);}

                        return RedirectToAction(nameof(Login));
                }


                [HttpGet]
                public IActionResult Login()
                {
                    var loginVM = new EmployeeLoginVM();
                    return View(loginVM);
                }



                [HttpPost]
                public async Task<IActionResult> Login(EmployeeLoginVM employeeLoginVM)
                {
                    if (!ModelState.IsValid)
                    {
                        return View(employeeLoginVM);
                    }
                try
                {
                    var employee = new Employee
                    {
                        Email = employeeLoginVM.Email,
                        Password = employeeLoginVM.Password
                    };

                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, employee.Email),
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, principal
                    );

                }
                catch (Exception)
                {
                    throw;
                }

                    return Redirect("/Home/Welcome");
                }

            

                [HttpGet]
                [Route("/employee/logout")]
                public async Task<IActionResult> Logout()
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    return Redirect("/");
                }
            }
        }
