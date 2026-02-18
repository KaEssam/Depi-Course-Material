using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal class Print<T> where T : IPrint
    {
        public T Value { get; set; }

        public void PrintValue()
        {
            Console.WriteLine(Value);
        }
    }
}
