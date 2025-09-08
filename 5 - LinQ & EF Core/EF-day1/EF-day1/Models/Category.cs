using System;
using System.Collections.Generic;

namespace EF_day1.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product1> Product1s { get; set; } = new List<Product1>();
}
