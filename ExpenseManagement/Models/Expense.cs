using System;
using System.Collections.Generic;
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
       public int UserId { get; set; }
       public string Status { get; set; }
       public List<Comment> Comments { get; set; }
       public string Receipt { get; set; }

        public Expense() { }

        public void AddComment(Comment newComment)
        {
            if(Comments == null)
            {
                Comments = new List<Comment>();
            }
            Comments.Add(newComment);
        }



        internal void UpdateStatus(string newStatus)
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
                case "Payment":
                    Status = "Paid";
                    break;
            }
        }
    } 
}
