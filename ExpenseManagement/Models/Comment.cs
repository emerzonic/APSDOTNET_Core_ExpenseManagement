using System;
namespace ExpenseManagement.Models
{
    public class Comment
    {
        public Guid ID { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }

        public Comment() { }
    }
}
