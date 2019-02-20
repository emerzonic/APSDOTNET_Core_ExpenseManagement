using System;
using ExpenseManagement.Data;
using ExpenseManagement.Models;
using ExpenseManagement.ViewModels;

namespace ExpenseManagement.Repository
{
    public class CommentRepository: ICommentRepository
    {
        private readonly ExpenseMangtDbContext _context;

        public CommentRepository(ExpenseMangtDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Save()
        {

        }
    }
}
