    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using ExpenseManagement.Data;
    using ExpenseManagement.Models;
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
            public ExpenseController(ExpenseMangtDbContext dbContext)
            {
                context = dbContext;
            }


            [HttpGet]
            public IActionResult Dashboard()
            {
                List<Expense> expenses = context.Expenses.ToList();
                return View(expenses);
            }



            [HttpGet]
            public IActionResult Add()
            {
                AddExpenseViewModel addExpense = new AddExpenseViewModel();
                return View(addExpense);
            }

            [HttpPost]
            public IActionResult Add(AddExpenseViewModel addExpenseVM)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Expense newExpense = new Expense
                        {
                            Description = addExpenseVM.Description,
                            Amount = addExpenseVM.Amount,
                            Date = addExpenseVM.Date,
                            Comments = addExpenseVM.Comments,
                            Receipt = addExpenseVM.Receipt,
                            Status = "New",
                            EmployeeId = 1
                        };
                        context.Add(newExpense);
                        context.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    } 
                        return Redirect("/Expense/Dashboard");
                }
                return View(addExpenseVM);
            }



            [HttpGet]
            [Route("/Expense/Detail/{id}")]
            public IActionResult Detail(int id)
            {
                Expense expense = null;
                try
                {
                    expense =  context.Expenses.Single(e => e.ID == id);
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
                Expense expense = null;
                try
                {
                    expense = context.Expenses.Single(e => e.ID == id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                UpdateExpenseViewModel updateExpense = new UpdateExpenseViewModel {
                    Description = expense.Description,
                    Amount = expense.Amount,
                    Date = expense.Date,
                    Comments = expense.Comments,
                    Receipt = expense.Receipt,
                    Status = expense.Status,
                    ID = expense.ID
                };
                return View(updateExpense);
            }


            [HttpPost]
            public IActionResult Edit(UpdateExpenseViewModel updatedExpense)
            {
                if (ModelState.IsValid)
                {
                    Expense expense = null;
                    try
                    {
                        expense = context.Expenses.Single(e => e.ID == updatedExpense.ID);
                        expense.Description = updatedExpense.Description;
                        expense.Amount = updatedExpense.Amount;
                        expense.Date = updatedExpense.Date;
                        expense.Comments = updatedExpense.Comments;
                        expense.Receipt = updatedExpense.Receipt;
                        context.Entry(expense).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return Redirect("/Expense/Detail/"+ expense.ID);
                }
                return View(updatedExpense);
            }




            [HttpGet]
            [Route("/Expense/Delete/{id}")]
            public IActionResult Delete(int id)
            {
                try
                {
                   Expense expense = context.Expenses.Single(e => e.ID == id);
                   context.Remove(expense);
                   context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Redirect("/Expense/Dashboard");
            }


            [HttpGet]
            [Route("/Expense/Review/{id}")]
            public IActionResult Review(int id)
            {
                Expense expense = null;
                try
                {
                    expense = context.Expenses.Single(e => e.ID == id);
                    expense.Status = "In Review";
                    context.SaveChanges();
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
