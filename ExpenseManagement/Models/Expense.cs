using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
    public class Expense
    {
       public Guid ID { get; set; }
       public string Description { get; set; }
       public double Amount { get; set; }
       public string Date { get; set; }
       public Guid UserId { get; set; }
       public string Status { get; set; }
       public List<Comment> Comments { get; set; }
       public string Receipt { get; set; }

        public Expense() {
            Status = "New";
            Comments = new List<Comment>();
        }

        public void AddComment(Comment newComment)
        {
            Comments.Add(newComment);
        }

        internal void UpdateExpenseStatus(string newStatus)
        {
            switch (newStatus)
            {
                case "Review":
                    Status = "In Review";
                    break;
                case "Reject":
                    Status = "Rejected";
                    break;
                case "Approve":
                    Status = "Approved";
                    break;
                case "Pay":
                    Status = "Paid";
                    break;
            }
        }
    } 
}
