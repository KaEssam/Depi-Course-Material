using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
<<<<<<< HEAD
        public string Title { get; set; }
=======


        [Required(ErrorMessage ="Task Title Requierd")]
        [StringLength(50,ErrorMessage = "Title cant be more than 50 char")]
        public string Title { get; set; }
        
        public bool IsComplete { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }
>>>>>>> 6637ba3848b8a5abbbf0993260116f21b21a1fa6
    }
}
