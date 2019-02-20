using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.ViewModels
{
    public class AddExpenseVM
    {   
        [Required]
        public string Description { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Comments { get; set; }
        [Required]
        public string Receipt { get; set; }
    }
}
