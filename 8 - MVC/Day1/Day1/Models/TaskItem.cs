using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="Task Title Requierd")]
        [StringLength(50,ErrorMessage = "Title cant be more than 50 char")]
        public string Title { get; set; }
        
        public bool IsComplete { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
