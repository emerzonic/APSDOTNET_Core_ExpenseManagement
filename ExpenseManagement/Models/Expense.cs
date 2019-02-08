using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
    public class Expense
    {
       [StringLength(255)]
       public int ID { get; set; }
       public string Description { get; set; }
       public Decimal Amount { get; set; }
       public DateTime Date { get; set; }
       public int EmployeeId { get; set; }
       public string Status { get; set; }
       public string Comments { get; set; }
       public string Receipt { get; set; }

        public Expense() { }
    } 
}
