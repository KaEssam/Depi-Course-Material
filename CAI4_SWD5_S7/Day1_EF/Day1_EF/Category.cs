using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Day1_EF
{
    [Table("category", Schema = "Production")]
    //[PrimaryKey(nameof(CategoryCode))]
    internal class Category
    {
        [Key]
        public int CategoryCode { get; set; }

        [Required]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Invalid Name")]
        [Column("Category_Name")]
        //[Key]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [NotMapped]
        public string CatInfo => $"{Name}";

        public ICollection<Product> Products { get; set; }
    }
}
