using System;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Data
{
    public class ExpenseMangtDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ExpenseMangtDbContext(
            DbContextOptions<ExpenseMangtDbContext> options
            ) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            base.OnModelCreating(builder);
            builder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });
            builder.Entity<ApplicationUser>().Property(u => u.UserName).HasMaxLength(128);
            builder.Entity<ApplicationUser>().Property(u => u.Email).HasMaxLength(128);
            builder.Entity<ApplicationUser>().Property(u => u.Id).HasMaxLength(128);
            builder.Entity<ApplicationUser>().Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Entity<ApplicationUser>().Property(u => u.NormalizedEmail).HasMaxLength(128);
            builder.Entity<ApplicationUser>().Property(u => u.NormalizedUserName).HasMaxLength(128);
            builder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(128);
            builder.Entity<IdentityRole>().Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Entity<IdentityRole>().Property(r => r.Id).HasMaxLength(128);
            builder.Entity<IdentityRole>().Property(r => r.NormalizedName).HasMaxLength(128);
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=8889;database=expenseManagement;uid=root;password=root;");
        }
    }
}
