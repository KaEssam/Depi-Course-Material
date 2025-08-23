using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
  public static  class  StringExtensions
    {
        //public static bool IsLongerThan(string input, int len)
        //{
        //    return input.Length > len;
        //}


        public static bool IsLongerThan(this string input, int len)
        {
            return input.Length > len;
        }

        public static void Print(this object input)
        {
            Console.WriteLine(input);
        }

        public static bool IsValidEmail(this string input) 
        {
            //empty, white space, @

            if (string.IsNullOrWhiteSpace(input) || !input.Contains('@') || string.IsNullOrEmpty(input))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
