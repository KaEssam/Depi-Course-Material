using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal class PrintInt : IPrint
    {
       
        public int Value { get; set; } 


        public void Print()
        {
            Console.WriteLine(Value);
        }

        public string ToPrintString()
        {
            return $"Int: {Value}";
        }
    }
}
