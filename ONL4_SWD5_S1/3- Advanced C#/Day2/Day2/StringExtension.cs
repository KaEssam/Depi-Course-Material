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
        }

        public static string Captialize(this string input)
        {
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
