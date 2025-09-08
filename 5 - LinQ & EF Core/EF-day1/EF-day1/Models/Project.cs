using System;
using System.Collections.Generic;

namespace EF_day1.Models;

public partial class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
