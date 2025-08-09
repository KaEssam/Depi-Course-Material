using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S1_Day3
{
   abstract class EBook : Book
    {
        //public string Title { get; set; }
        //public int EBookId { get; set; }
        //public decimal Price { get; set; }
        //public string Category { get; set; }

        public override string ToString()
        {
            return $"Book:{Title} by {Author}";
        }
    }
}
