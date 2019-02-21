using System;
using System.Collections.Generic;
using ExpenseManagement.Models;

namespace ExpenseManagement.ViewModels
{
    public class ExpensesAndUserVM
    {

        public List<Expense> Expenses { get; set; }
        public Guid UserId { get; set; }
        public bool IsManager { get; set; }
        public bool IsAdmin { get; set; }

        public ExpensesAndUserVM(){}
    }
}
