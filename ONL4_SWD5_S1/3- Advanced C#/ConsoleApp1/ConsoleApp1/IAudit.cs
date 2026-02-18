using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal interface IAudit
    {
        DateTime createAt { get; set;  }
    }
}
