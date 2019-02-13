using System;
using System.Collections.Generic;
using ExpenseManagement.Data;
using ExpenseManagement.Models;

namespace ExpenseManagement.Repository
{
    public interface IExpenseRepository
    {

        void AddExpense(Expense expense);
        List<Expense> GetAllExpenses();
        Expense GetOneExpense(int id);
        void UpdateExpense(Expense expense);
        void DeleteExpense(Expense expense);
        void Save();
    }
}
