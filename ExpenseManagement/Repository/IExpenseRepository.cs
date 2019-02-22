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
        List<Expense> GetExpensesByUserId(Guid userId);
        Expense GetOneExpense(Guid expenseId);
        void UpdateExpense(Expense expense);
        void DeleteExpense(Expense expense);
        void Save();
    }
}
