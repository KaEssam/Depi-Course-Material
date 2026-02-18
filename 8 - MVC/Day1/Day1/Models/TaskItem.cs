using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
