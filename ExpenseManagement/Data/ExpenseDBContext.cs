using System;
using ExpenseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Data
{
    public class ExpenseMangtDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ExpenseMangtDbContext(
            DbContextOptions<ExpenseMangtDbContext> options
            ):base (options)
        {
        }
    }
}
