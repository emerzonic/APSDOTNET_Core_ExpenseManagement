using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManagement.Models;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    public class ExpenseController : Controller
    {
        static private List<Expense> Expenses = new List<Expense>();
        static private ArrayList Statuses = new ArrayList();
        static Random rnd = new Random();

        public IActionResult Dashboard()
        {
            return View(Expenses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddExpenseViewModel addExpense = new AddExpenseViewModel();
            return View(addExpense);
        }

        [HttpPost]
        public IActionResult Add(AddExpenseViewModel addExpense)
        {
            if (ModelState.IsValid)
            {
                Statuses.Add("New");
                Statuses.Add("Paid");
                Statuses.Add("In Review");
                Statuses.Add("Canceled/Rejected");
                int r = rnd.Next(Statuses.Count);
                Expense newExpense = new Expense
                {
                    Description = addExpense.Description,
                    Amount = addExpense.Amount,
                    Date = addExpense.Date,
                    Comments = addExpense.Comments,
                    Receipt = addExpense.Receipt,
                    Status = Statuses[r].ToString(),
                    Employee = new Employee
                    {
                        FirstName = "Emerson",
                        LastName = "Doyah",
                        UserName = "emerzonic",
                        Role = new Role
                        {
                            Name = "Employee"
                        }
                    }

                };

                Expenses.Add(newExpense);
                return Redirect("/Expense/Dashboard");
            }
            return View(addExpense);
        }

        [HttpGet]
        [Route("/Detail/{id}")]
        public IActionResult Detail(int id)
        {
            return View();
        }


        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }
    }
}
