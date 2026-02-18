using System;
using System.Collections.Generic;
using System.Text;

namespace Day2
{
    internal static class StringHelper
    {
        public static bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}
