using System.ComponentModel.DataAnnotations;

namespace TMS.core.Entites
{
    public class TaskItem
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
