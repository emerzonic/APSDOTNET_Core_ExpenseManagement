using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using ExpenseManagement.Service;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExpenseManagement.Controllers
{

    [Authorize]
    public class ExpenseController : Controller
    {
        private IExpenseService _expenseService;
        private UserManager<ApplicationUser> _userManager;

        public ExpenseController(ExpenseMangtDbContext dbContext,
                IExpenseService expenseService,
                UserManager<ApplicationUser> manager
            )
        {
            _expenseService = expenseService;
            _userManager = manager;
        }


        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            List<Expense> expenses = new List<Expense>();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var isManager = await _userManager.IsInRoleAsync(user, "Manager");
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (isManager || isAdmin)
            {
                expenses = _expenseService.GetAllExpenses();
            }
            else
            {
                expenses = _expenseService.GetExpensesByUserId(new Guid(user.Id));
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
        public async Task <IActionResult> Add(AddExpenseVM addExpenseVM)
        {
            if (!ModelState.IsValid)
            {
                return View(addExpenseVM);
            }

            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                _expenseService.AddExpense(addExpenseVM, user);
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
        public async Task<IActionResult> Detail(Guid id)
        {
            Expense expense = null;

            try
            {
                expense = _expenseService.GetOneExpense(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Redirect("/Expense/Dashboard");
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var isManager = await _userManager.IsInRoleAsync(user, "Manager");
            var expenseAndCommentVM = new ExpenseAndCommentVM
            {
                Expense = expense,
                AddCommentVM = new AddCommentVM(),
                UserId = new Guid(user.Id),
                IsManager = isManager
            };

            return View(expenseAndCommentVM);
        }




        [HttpGet]
        [Route("/Expense/Edit/{id}")]
        public IActionResult Edit(Guid id)
        {
            UpdateExpenseVM updateExpense = null;

            try
            {
                Expense expense = _expenseService.GetOneExpense(id);
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
                return Redirect("/Expense/Dashboard");
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
                _expenseService.UpdateExpense(updatedExpense);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Redirect($"/Expense/Detail/{updatedExpense.ID}");
        }





        [HttpGet]
        [Route("/Expense/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _expenseService.DeleteExpense(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Redirect("/Expense/Dashboard");
        }


        [HttpGet]
        [Route("/Expense/UpdateStatus/{expenseStatus}/{expenseId}")]
        public IActionResult UpdateStatus(string expenseStatus, Guid expenseId)
        {
            try
            {
                _expenseService.UpdateExpenseStatus(expenseStatus, expenseId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Redirect($"/Expense/Detail/{expenseId}");
        }
    }
}
