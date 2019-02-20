using System;
using ExpenseManagement.Models;
using ExpenseManagement.Repository;
using ExpenseManagement.ViewModels;

namespace ExpenseManagement.Service
{
    public class CommentService:ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IExpenseService _expenseService;

        public CommentService(ICommentRepository commentRepository,
                              IExpenseService expenseRepository)
        {
            _commentRepository = commentRepository;
            _expenseService = expenseRepository;
        }

        public void AddComment(AddCommentVM addCommentVM, ApplicationUser user)
        {
            var expense = _expenseService.GetOneExpense(addCommentVM.ExpenseId);
            var comment = new Comment
            {
                Text = addCommentVM.Text,
                Date = DateTime.Now.ToShortDateString(),
                Author = user.FirstName
            };

            expense.AddComment(comment);
            _commentRepository.AddComment(comment);
        }

    }
}
