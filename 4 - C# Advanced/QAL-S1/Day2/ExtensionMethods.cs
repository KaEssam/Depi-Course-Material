using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    static class ExtensionMethods
    {
        // => true if even

        //public static bool IsEven(int num)
        //{
        //    return num % 2 == 0;
        //}


        public static bool IsEven(this int num)
        {
            return num % 2 == 0;
        }

        public static string ToCapitlized(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        public static bool IsLongerThan(this string input, int len)
        {
            return input.Length > len;
        }



        //public static void Print<T>(T input)
        //{
        //    Console.WriteLine(input);
        //}


        public static void Print(this object input)
        {
            Console.WriteLine(input);
        }

    }
    
}
