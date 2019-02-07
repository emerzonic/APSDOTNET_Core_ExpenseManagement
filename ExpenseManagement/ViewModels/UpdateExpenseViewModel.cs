using System;
using System.ComponentModel.DataAnnotations;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.ViewModels
{
    public class UpdateExpenseViewModel : AddExpenseViewModel
    {
        public string Status { get; set; }
        [Required]
        public int ID { get; set; }
      
        public UpdateExpenseViewModel()
        {

        }


    }
}
