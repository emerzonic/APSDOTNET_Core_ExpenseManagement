using System;
namespace ExpenseManagement.Models
{
    public class Comment
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public string DateString { get; set; }

        public Comment(){}
    }
}
