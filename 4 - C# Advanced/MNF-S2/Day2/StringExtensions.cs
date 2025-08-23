using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    static class StringExtensions
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

        //empty, white space, @

        /// <summary>
        /// check valid mails
        /// </summary>
        /// <param name="Email"></param>
        /// <returns>bool</returns>
        public static bool IsValidEmail(this string Email)
        {
            if(string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
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
