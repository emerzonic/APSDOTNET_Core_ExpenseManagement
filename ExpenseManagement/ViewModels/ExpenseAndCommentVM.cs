using System;
using ExpenseManagement.Models;

namespace ExpenseManagement.ViewModels
{
    public class ExpenseAndCommentVM
    {

        public Expense Expense { get; set; }
        public AddCommentVM AddCommentVM { get; set; }
        public Guid UserId { get; set; }
        public bool IsManager { get; set; }
        public ExpenseAndCommentVM(){}
    }
}
