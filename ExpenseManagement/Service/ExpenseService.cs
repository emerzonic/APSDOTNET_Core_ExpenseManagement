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
        private IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }


        public void AddExpense(AddExpenseVM addExpenseVM, ApplicationUser user)
        {

            Expense newExpense = new Expense
            {
                Description = addExpenseVM.Description,
                Amount = addExpenseVM.Amount,
                Date = DateTime.Parse(addExpenseVM.Date).ToLongDateString(),
                Comments = new List<Comment>(),
                Receipt = addExpenseVM.Receipt,
                UserId = new Guid(user.Id),
            };

            if (!string.IsNullOrEmpty(addExpenseVM.Comments))
            {
                var newComment = new Comment
                {
                    Text = addExpenseVM.Comments,
                    Author = user.FirstName,
                    Date = DateTime.Now.ToLongDateString(),
                    ID = Guid.NewGuid()
                };

                newExpense.AddComment(newComment);
            };

            newExpense.ID = Guid.NewGuid();
            _expenseRepository.AddExpense(newExpense);
        }


        public void DeleteExpense(Guid id)
        {
            Expense expense = _expenseRepository.GetOneExpense(id);
            _expenseRepository.DeleteExpense(expense);
        }


        public List<Expense> GetAllExpenses()
        {
            return _expenseRepository.GetAllExpenses();
        }

        public List<Expense> GetExpensesByUserId(Guid userId)
        {
            return _expenseRepository.GetExpensesByUserId(userId);
        }

        public Expense GetOneExpense(Guid id)
        {
            return _expenseRepository.GetOneExpense(id);
        }


        public void UpdateExpense(UpdateExpenseVM updatedExpense)
        {
            Expense expense = _expenseRepository.GetOneExpense(updatedExpense.ID);
            expense.Description = updatedExpense.Description;
            expense.Amount = updatedExpense.Amount;
            expense.Date = updatedExpense.Date;

            if (!string.IsNullOrEmpty(updatedExpense.Receipt))
            {
                expense.Receipt = updatedExpense.Receipt;
            }
            _expenseRepository.UpdateExpense(expense);
        }


        public void UpdateExpenseStatus(string newStatus, Guid id)
        {
            Expense expense = _expenseRepository.GetOneExpense(id);
            expense.UpdateExpenseStatus(newStatus);
            _expenseRepository.Save();
        }
    }
}
