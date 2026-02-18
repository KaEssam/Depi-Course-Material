using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Day1_EF
{
    internal class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        //[ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category category { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<AbdoList> Abdos { get; set; }
    }
}
