using System;
using ExpenseManagement.Models;

namespace ExpenseManagement.ViewModels
{
    public class ExpenseAndCommentVM
    {

        public Expense Expense { get; set; }
        public AddCommentVM AddCommentVM { get; set; }
        public ExpenseAndCommentVM(){}
    }
}
