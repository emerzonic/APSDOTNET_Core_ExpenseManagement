using System;
namespace ExpenseManagement.Models
{
    public class Comment
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        private string Text;
        private string Date;

        public Comment() { }


        public Guid GetID() { return ID; }

        public void SetID(Guid id) { ID = id; }

        public string GetText() { return Text; }

        public void SetText(string text) { Text = text; }

        public Guid GetUserId() { return UserId; }

        public void SetUserId(Guid userId){UserId = userId;}

        public string GetDate(){return Date;}

        public void SetDate(string date){Date = date;}
    }
}
