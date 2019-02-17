using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using ExpenseManagement.Repository;
using ExpenseManagement.ViewModels;

namespace ExpenseManagement.Service
{
    public class ExpenseService : IExpenseService
    {
        private IExpenseRepository expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }



        public void AddExpense(AddExpenseVM addExpenseVM, string userId)
        {
            Expense newExpense = new Expense
            {
                Description = addExpenseVM.Description,
                Amount = addExpenseVM.Amount,
                Date = addExpenseVM.Date,
                Comments = new List<Comment>(),
                Receipt = addExpenseVM.Receipt,
                UserId = new Guid(userId),
            };

            if (!string.IsNullOrEmpty(addExpenseVM.Comments))
            {
                var newComment = new Comment();
                newComment.SetText(addExpenseVM.Comments);
                newComment.SetUserId(new Guid(userId));
                newComment.SetDate(DateTime.Now.ToLongDateString());
                newComment.SetID(Guid.NewGuid());
                newExpense.AddComment(newComment);
            };

            newExpense.ID = Guid.NewGuid();
            expenseRepository.AddExpense(newExpense);
        }




        public void DeleteExpense(Guid id)
        {
            Expense expense = expenseRepository.GetOneExpense(id);
            expenseRepository.DeleteExpense(expense);
        }




        public List<Expense> GetAllExpenses()
        {
            return expenseRepository.GetAllExpenses();
        }



        public Expense GetOneExpense(Guid id)
        {
            return expenseRepository.GetOneExpense(id);
        }



        public void UpdateExpense(UpdateExpenseVM updatedExpense)
        {
            Expense expense = expenseRepository.GetOneExpense(updatedExpense.ID);
            expense.Description = updatedExpense.Description;
            expense.Amount = updatedExpense.Amount;
            expense.Date = updatedExpense.Date;
            expense.Receipt = updatedExpense.Receipt;
            expenseRepository.UpdateExpense(expense);
        }




        public void UpdateExpenseStatus(string newStatus, Guid id)
        {
            Expense expense = expenseRepository.GetOneExpense(id);
            expense.UpdateStatus(newStatus);
            expenseRepository.Save();
        }

    }
}
