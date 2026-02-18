using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Box<T>  where T : new()
    {
        public T box { get; set; }
    }
}
