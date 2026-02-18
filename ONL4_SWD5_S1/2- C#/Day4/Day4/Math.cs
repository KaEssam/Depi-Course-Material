using System;
using System.Collections.Generic;
using System.Text;

namespace Day4
{
    internal static class MathHelper
    {

        public static int UsedTime = 0;

        public static int Sum(params int[] values)
        {
            int sum = 0;
            foreach (int i in values)
            {
                sum += i; 
            }
            ++UsedTime;
            return sum;
        }

        static MathHelper()
        {
            Console.WriteLine("static constructor");
            
        }
    }
}
