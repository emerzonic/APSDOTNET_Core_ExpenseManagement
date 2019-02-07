using System.Security.Claims;
using System.Threading.Tasks;
using ExpenseManagement.Models;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: /<controller>/
        public IActionResult SignupForm()
        {
            EmployeeSignupVM signupVM = new EmployeeSignupVM();
            return View(signupVM);
        }

        public IActionResult Signup()
        {
            return View();
        }
        

        // GET: /<controller>/
        public IActionResult LoginForm()
        {
            EmployeeLoginVM loginVM = new EmployeeLoginVM();
            return View(loginVM);
        }


        [HttpPost]
        public async Task<IActionResult> Login(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Email))
            {
                return RedirectToAction(nameof(Login));
            }

            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, employee.Email),
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal
            );
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
