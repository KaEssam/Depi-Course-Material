using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class TaskMV
    {
        [Required(ErrorMessage = "Task Title Requierd")]
        [StringLength(50, ErrorMessage = "Title cant be more than 50 char")]
        [Display(Name ="Task Title")]
        public string Title { get; set; }



        [Display(Name = "Priority Level")]
        public string Priority { get; set; } = "Normal";

        [Display(Name ="Is Completed")]
        public bool IsComplete { get; set; }
    }
}
