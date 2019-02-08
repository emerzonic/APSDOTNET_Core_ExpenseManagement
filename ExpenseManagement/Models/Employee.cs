using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Models
{
    public class Employee: ApplicationUser
    {
        //public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Employee() { }

    }
}
