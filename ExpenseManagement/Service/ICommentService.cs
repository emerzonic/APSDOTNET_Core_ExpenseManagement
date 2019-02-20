using System;
using ExpenseManagement.Models;
using ExpenseManagement.ViewModels;

namespace ExpenseManagement.Service
{
    public interface ICommentService
    {
        void AddComment(AddCommentVM addCommentVM, ApplicationUser user);
    }
}
