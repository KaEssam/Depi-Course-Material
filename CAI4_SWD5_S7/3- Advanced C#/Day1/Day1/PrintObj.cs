using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal class PrintObj
    {
        public object Value { get; set; }

        public void Print()
        {
            Console.WriteLine(Value);
        }
    }
}
