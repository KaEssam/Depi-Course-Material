using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Emp : IAudit
    {
        public string Name { get; set; }
        public DateTime createAt {  get; set; } = DateTime.Now;
    }
}
