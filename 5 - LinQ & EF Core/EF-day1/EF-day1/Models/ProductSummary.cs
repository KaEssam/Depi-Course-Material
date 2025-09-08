using System;
using System.Collections.Generic;

namespace EF_day1.Models;

public partial class ProductSummary
{
    public string CategoryName { get; set; } = null!;

    public int? TotalProducts { get; set; }

    public decimal? AvgPrice { get; set; }

    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }
}
