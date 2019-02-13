using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using ExpenseManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private ExpenseMangtDbContext context;
        public ExpenseRepository(ExpenseMangtDbContext dbContext)
        {
            this.context = dbContext;
        }

      


        public void AddExpense(Expense expense)
        {
            context.Add(expense);
            context.SaveChanges();
        }

        public void DeleteExpense(Expense expense)
        {
            context.Remove(expense);
            context.SaveChanges();
        }

        public List<Expense> GetAllExpenses()
        {
            return  context.Expenses.ToList();

        }

     

        public Expense GetOneExpense(int id)
        {
            return context.Expenses.Single(e => e.ID == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateExpense(Expense expense)
        {
            context.Entry(expense).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
