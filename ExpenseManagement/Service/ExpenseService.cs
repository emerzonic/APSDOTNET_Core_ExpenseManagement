using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using ExpenseManagement.Repository;
using ExpenseManagement.ViewModels;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ExpenseManagement.Service
{
    public class ExpenseService:IExpenseService
    {
        private IExpenseRepository expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }

    

        public void AddExpense(AddExpenseVM addExpenseVM)
        {
            Expense newExpense = new Expense
            {
                Description = addExpenseVM.Description,
                Amount = addExpenseVM.Amount,
                Date = addExpenseVM.Date,
                Comments = new List<Comment>(),
                Receipt = addExpenseVM.Receipt,
                Status = "New",
                UserId = 1
            };
            if (!string.IsNullOrEmpty(addExpenseVM.Comments))
            {
                var newComment = new Comment
                {
                    Text = addExpenseVM.Comments,
                    UserId = 1,
                    DateString = DateTime.Now.ToLongDateString()

                };
                newExpense.AddComment(newComment);
            };
            expenseRepository.AddExpense(newExpense);
        }




        public void DeleteExpense(int id)
        {
            Expense expense = expenseRepository.GetOneExpense(id);
            expenseRepository.DeleteExpense(expense);
        }




        public List<Expense> GetAllExpenses()
        {
            return expenseRepository.GetAllExpenses();

        }

   

        public Expense GetOneExpense(int id)
        {
            return expenseRepository.GetOneExpense(id);
        }



        public void UpdateExpense(UpdateExpenseVM updatedExpense)
        {
            Expense expense = expenseRepository.GetOneExpense(updatedExpense.ID);
            expense.Description = updatedExpense.Description;
            expense.Amount = updatedExpense.Amount;
            expense.Date = updatedExpense.Date;
            expense.Comments = updatedExpense.Comments;
            expense.Receipt = updatedExpense.Receipt;
            expenseRepository.UpdateExpense(expense);
        }

        public void UpdateExpenseStatus(string newStatus, int id)
        {
            Expense expense = expenseRepository.GetOneExpense(id);
            expense.UpdateStatus(newStatus);
            expenseRepository.Save();
        }

    }
}
