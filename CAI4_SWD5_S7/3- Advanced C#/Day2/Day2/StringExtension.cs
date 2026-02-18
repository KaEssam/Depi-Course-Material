using System;
using System.Collections.Generic;
using System.Text;

namespace Day2
{
    internal static class StringExtension
    {
        public static bool IsValidEmail(this string email)
        {
            return email.Contains("@") && email.Contains(".");
            //return email

        }

        public static string Capitalize(this string str)
        {
            return char.ToUpper(str[0])+ str.Substring(1).ToLower();
        }
    }
}
