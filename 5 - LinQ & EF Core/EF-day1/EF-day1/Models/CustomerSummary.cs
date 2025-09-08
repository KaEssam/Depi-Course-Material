using System;
using System.Collections.Generic;

namespace EF_day1.Models;

public partial class CustomerSummary
{
    public string CustomerName { get; set; } = null!;

    public string? City { get; set; }

    public string? State { get; set; }
}
