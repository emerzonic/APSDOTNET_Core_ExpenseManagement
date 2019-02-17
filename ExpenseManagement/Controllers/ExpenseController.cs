using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using ExpenseManagement.Service;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Controllers
{

    [Authorize]
    public class ExpenseController : Controller
    {
        private IExpenseService expenseService;
        private UserManager<ApplicationUser> manager;
        public ExpenseController(ExpenseMangtDbContext dbContext,
                IExpenseService expenseService,
                UserManager<ApplicationUser> manager
            )
        {
            this.expenseService = expenseService;
            this.manager = manager;
        }


        [HttpGet]
        public IActionResult Dashboard()
        {
            List<Expense> expenses = null;

            try
            {
                expenses = expenseService.GetAllExpenses();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(expenses);
        }




        [HttpGet]
        public IActionResult Add()
        {
            AddExpenseVM addExpense = new AddExpenseVM();
            return View(addExpense);
        }




        [HttpPost]
        public IActionResult Add(AddExpenseVM addExpenseVM)
        {
            if (!ModelState.IsValid)
            {
                return View(addExpenseVM);
            }

            try
            {
                Console.Write(this.User);
                string userId =  manager.GetUserId(HttpContext.User);
                expenseService.AddExpense(addExpenseVM, userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(addExpenseVM);
            }

            return Redirect("/Expense/Dashboard");
        }




        [HttpGet]
        [Route("/Expense/Detail/{id}")]
        public IActionResult Detail(Guid id)
        {
            Expense expense = null;

            try
            {
                expense = expenseService.GetOneExpense(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(expense);
        }




        [HttpGet]
        [Route("/Expense/Edit/{id}")]
        public IActionResult Edit(Guid id)
        {
            UpdateExpenseVM updateExpense = null;

            try
            {
                Expense expense = expenseService.GetOneExpense(id);
                updateExpense = new UpdateExpenseVM
                {
                    Description = expense.Description,
                    Amount = expense.Amount,
                    Date = expense.Date,
                    Receipt = expense.Receipt,
                    ID = expense.ID
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(updateExpense);
        }


        [HttpPost]
        public IActionResult Edit(UpdateExpenseVM updatedExpense)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedExpense);
            }

            try
            {
                expenseService.UpdateExpense(updatedExpense);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Redirect("/Expense/Detail/" + updatedExpense.ID);
        }





        [HttpGet]
        [Route("/Expense/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                expenseService.DeleteExpense(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Redirect("/Expense/Dashboard");
        }


        [HttpGet]
        [Route("/Expense/UpdateStatus/{expenseStatus}/{id}")]
        public IActionResult UpdateStatus(string expenseStatus, Guid id)
        {
            try
            {
                expenseService.UpdateExpenseStatus(expenseStatus, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Redirect("/Expense/Detail/" + id);
        }
    }
}
