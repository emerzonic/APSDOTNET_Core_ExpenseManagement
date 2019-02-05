using System;
namespace ExpenseManagement.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Expense Expense { get; set; }
        public Role Role { get; set; }

        public Employee(){}

    }
}
