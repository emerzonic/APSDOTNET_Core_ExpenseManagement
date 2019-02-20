using System;
using System.Threading.Tasks;
using ExpenseManagement.Models;
using ExpenseManagement.Service;
using ExpenseManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    public class CommentController: Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentController(ICommentService commentService,
                                 UserManager<ApplicationUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Add(AddCommentVM addCommentVM)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Expense/Detail/" + addCommentVM.ExpenseId);
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            _commentService.AddComment(addCommentVM, user);

            return Redirect($"/Expense/Detail/{ addCommentVM.ExpenseId}");
        }
    }
}
