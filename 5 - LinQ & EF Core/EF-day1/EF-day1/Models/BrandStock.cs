using System;
using System.Collections.Generic;

namespace EF_day1.Models;

public partial class BrandStock
{
    public string BrandName { get; set; } = null!;

    public int? TotalProducts { get; set; }
}
