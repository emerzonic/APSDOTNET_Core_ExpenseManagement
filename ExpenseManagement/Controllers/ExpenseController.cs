using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using ExpenseManagement.Service;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Controllers
{

    [Authorize]
        public class ExpenseController : Controller
        {
            private ExpenseMangtDbContext context;
            private IExpenseService expenseService;
            public ExpenseController(ExpenseMangtDbContext dbContext,
                    IExpenseService expenseService)
            {
            this.context = dbContext;
            this.expenseService = expenseService;
            }


            [HttpGet]
            public IActionResult Dashboard(){
                List<Expense> expenses = null;
                try{
                    expenseService.GetAllExpenses();
                }catch (Exception ex){
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
            public IActionResult Add(AddExpenseVM addExpenseVM){
                if (!ModelState.IsValid){
                    return View(addExpenseVM);
                }
                try{
                    expenseService.AddExpense(addExpenseVM);
                }catch (Exception ex){
                    Console.WriteLine(ex.Message);
                } 
                return Redirect("/Expense/Dashboard");
            }
            

      

            [HttpGet]
            [Route("/Expense/Detail/{id}")]
            public IActionResult Detail(int id)
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
            public IActionResult Edit(int id)
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
                    Comments = expense.Comments,
                    Receipt = expense.Receipt,
                    Status = expense.Status,
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
            public IActionResult Delete(int id)
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
            [Route("/Expense/UpdateStatus/{status}/{id}")]
            public IActionResult UpdateStatus(string status, int id)
            {
                Expense expense = null;
                try
                {
                expenseService.UpdateExpenseStatus(status, id);
                expense = expenseService.GetOneExpense(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Redirect("/Expense/Detail/" + expense.ID);
            }




            [HttpGet]
            [Route("/Expense/Approve/{id}")]
            public IActionResult Approve(int id)
            {
                Expense expense = null;
                try
                {
                    expense = context.Expenses.Single(e => e.ID == id);
                    expense.Status = "Approved";
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Redirect("/Expense/Detail/"+ expense.ID);
            }

            [HttpGet]
            [Route("/Expense/Reject/{id}")]
            public IActionResult Reject(int id)
            {
                Expense expense = null;
                try
                {
                    expense = context.Expenses.Single(e => e.ID == id);
                    expense.Status = "Rejected";
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Redirect("/Expense/Detail/" + expense.ID);
            }



            [HttpGet]
            [Route("/Expense/Payment/{id}")]
            public IActionResult Pay(int id)
            {
                Expense expense = null;
                try
                {
                    expense = context.Expenses.Single(e => e.ID == id);
                    expense.Status = "Paid";
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Redirect("/Expense/Detail/" + expense.ID);
            }
        }
    }
