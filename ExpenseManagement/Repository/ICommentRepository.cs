using ExpenseManagement.Models;
using ExpenseManagement.ViewModels;

namespace ExpenseManagement.Repository
{
    public interface ICommentRepository
    {
        void AddComment(Comment comment);
    }
}