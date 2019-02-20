using System;
using System.Collections.Generic;
using ExpenseManagement.Models;
using ExpenseManagement.ViewModels;

namespace ExpenseManagement.Service
{
    public interface IExpenseService
    {
         List<Expense> GetAllExpenses();
        void AddExpense(AddExpenseVM expense, ApplicationUser user);
         Expense GetOneExpense(Guid id);
        void UpdateExpense(UpdateExpenseVM expense);
        void DeleteExpense(Guid id);
        void UpdateExpenseStatus(string status, Guid id);
    }
}
