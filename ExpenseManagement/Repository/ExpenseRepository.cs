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
        private ExpenseMangtDbContext _context;

        public ExpenseRepository(ExpenseMangtDbContext dbContext)
        {
            _context = dbContext;
        }


        public void AddExpense(Expense expense)
        {
            _context.Add(expense);
            _context.SaveChanges();
        }


        public void DeleteExpense(Expense expense)
        {
            _context.Remove(expense);
            _context.SaveChanges();
        }


        public List<Expense> GetAllExpenses()
        {

            List<Expense> expenses = _context.Expenses.OrderBy(e=>e.Date).ToList();
            return expenses;
        }


        public Expense GetOneExpense(Guid id)
        {
            return _context.Expenses
            .Include(e => e.Comments)
            .Single(e => e.ID == id);
        }


        public void Save()
        {
            _context.SaveChanges();
        }


        public void UpdateExpense(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
