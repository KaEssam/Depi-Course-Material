using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Box<T> where T: class
    {
        public T id { get; set; }

      public void printT(T VALUE)
        {
            Console.WriteLine(VALUE);
        }
    }
}
