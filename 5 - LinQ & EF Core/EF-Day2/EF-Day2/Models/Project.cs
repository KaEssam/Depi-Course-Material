using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Day2.Models
{
    [Table("Projects", Schema= "Prod")]
    class Project
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ProductId")]
        public byte ProjectSsN { get; set; }
        //[Column("ProductName")]
        //[Required]
        //[MaxLength(50)]
        public string Name { get; set; }


        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
