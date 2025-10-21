using Microsoft.AspNetCore.Identity;

namespace Day1.Models
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public ICollection<TaskItem> tasks { get; set; } = new List<TaskItem>();
    }
}
