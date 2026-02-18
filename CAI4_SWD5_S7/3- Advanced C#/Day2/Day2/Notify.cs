using System;
using System.Collections.Generic;
using System.Text;

namespace Day2
{
    delegate void notify(string msg);
    internal static class Notify
    {
        public static void SendEmail(string msg)
        {
            Console.WriteLine($"Email:{msg}");
        }

        public static void SendSms(string msg)
        {
            Console.WriteLine($"SMS:{msg}");
        }
    }
}
