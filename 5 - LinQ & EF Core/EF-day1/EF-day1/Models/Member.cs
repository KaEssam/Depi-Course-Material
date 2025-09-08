using System;
using System.Collections.Generic;

namespace EF_day1.Models;

public partial class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ProjectId { get; set; }

    public virtual Project? Project { get; set; }
}
