using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Notification
    {

        public delegate void NotifyDel(string msg);

        public event NotifyDel NotifyDelEvent;

        public NotifyDel notify;

        public void UserActtion( string action)
        {
            Console.WriteLine($"user did: {action}");

            NotifyDelEvent.Invoke($"[Notify] user did: {action}");
        }
    }
}
