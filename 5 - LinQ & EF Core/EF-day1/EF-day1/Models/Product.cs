using System;
using System.Collections.Generic;

namespace EF_day1.Models;

public partial class Product
{
    public string ProductName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal? PriceWithTax { get; set; }
}
