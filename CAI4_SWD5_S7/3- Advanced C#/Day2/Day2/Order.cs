using System;
using System.Collections.Generic;
using System.Text;

namespace Day2
{

    internal class Order
    {
        notify del;

        public void MakeOrder(string product, decimal price)
        {
            Console.WriteLine($"order placed: {product}-{price}");


            del.Invoke($"order confirmed {product}-{price}");
            //Console.WriteLine(del);

            ////nofiy user
            //Console.WriteLine($"Email: order confirmed {product}-{price}");
            //Console.WriteLine($"Sms: order: {product}-{price}");

            //del = SendEmail;
            //del += SendSms;


        }

        public Order(notify notifyDelgete)
        {
            del = notifyDelgete;
        }


        //public static void SendEmail(string msg)
        //{
        //    Console.WriteLine($"Email:{msg}"); 
        //}

        //public static void SendSms(string msg)
        //{
        //    Console.WriteLine($"SMS:{msg}");
        //}
    }
}
