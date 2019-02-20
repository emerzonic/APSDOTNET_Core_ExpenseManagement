using System;
using System.ComponentModel.DataAnnotations;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.ViewModels
{
    public class UpdateExpenseVM
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string Date { get; set; }
        public string Receipt { get; set; }

        public UpdateExpenseVM()
        {

        }


    }
}
