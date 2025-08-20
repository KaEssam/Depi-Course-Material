using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Box<T> 
    {
        public T Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //void printT(T value)
        //{
        //    Console.WriteLine(T);
        //}

        //public static T sum<T>(T num1, T num2)
        //{
        //    return $"{num1} - {num2}";
        //}
    }
}
