using System;
using System.Collections.Generic;
using ExpenseManagement.Models;
using ExpenseManagement.ViewModels;

namespace ExpenseManagement.Service
{
    public interface IExpenseService
    {
         List<Expense> GetAllExpenses();
        void AddExpense(AddExpenseVM expense);
         Expense GetOneExpense(int id);
        void UpdateExpense(UpdateExpenseVM expense);
        void DeleteExpense(int id);
        void UpdateExpenseStatus(string status, int id);
    }
}
