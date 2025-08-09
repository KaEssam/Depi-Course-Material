using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S2_Day3
{
    class Magazine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public static int Copies { get; set; } = 5;
    }
}
