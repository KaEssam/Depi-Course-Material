using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Notification
    {
        public delegate void NotificationDel(string msg);

        public event NotificationDel NotificationDelEvent;

        public NotificationDel notification;
        public void UserAction(string action)
        {
            Console.WriteLine($"user did: {action}");
            //notification.Invoke($"[Notication]: user did: {action}");
            NotificationDelEvent.Invoke($"[Notication]: user did: {action}");
        }
    }
}
