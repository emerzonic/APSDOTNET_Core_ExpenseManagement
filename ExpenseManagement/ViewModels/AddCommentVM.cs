using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.ViewModels
{
    public class AddCommentVM
    {   
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid ExpenseId { get; set; }
    }
}
