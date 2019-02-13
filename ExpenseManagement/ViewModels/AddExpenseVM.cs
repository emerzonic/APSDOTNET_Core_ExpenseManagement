using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.ViewModels
{
    public class AddExpenseVM
    {   
        [Required]
        public string Description { get; set; }
        [Required]
        public Decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        [Required]
        public string Receipt { get; set; }
    }
}
