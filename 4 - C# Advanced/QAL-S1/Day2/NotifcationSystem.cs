using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
     public class NotifcationSystem
    {
        public class Notify
        {
            public void SendSms(string msg) => Console.WriteLine($"[SMS] {msg}");
        }

        public class Logger
        {
            public void Log(string msg) => Console.WriteLine($"[Log]: {msg}");
        }
    }
}
