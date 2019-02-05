using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: /<controller>/
        public IActionResult SignupForm()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult SigninForm()
        {
            return View();
        }

        public IActionResult Signin()
        {
            return View();
        }
    }
}
