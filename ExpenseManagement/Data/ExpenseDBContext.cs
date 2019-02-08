using ExpenseManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Data
{
    public class ExpenseMangtDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ExpenseMangtDbContext(
            DbContextOptions<ExpenseMangtDbContext> options
            ):base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=8889;database=expenseDB;user=root;password=root");
        }
    }
}
