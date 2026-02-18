namespace Day2
{
    //public delegate void notifyDelgete(string msg);

    public delegate decimal CalcDiscount(decimal amount);

    internal class Program
    {
        static void Main(string[] args)
        {
            //string email = "kaessam@hotmail.com";
            //string name = "KARIM";

            ////string res = StringHelper.IsValidEmail(email) ? "Email is valid":"email not valid";
            //string res = email.Capitalize().IsValidEmail() ? "Email is valid":"email not valid";

            //Console.WriteLine(res);

            //Console.WriteLine(name.Capitalize());


            //notify notify;
            //notify =Notify.SendEmail;
            //notify += Notify.SendSms;
            ////notify += SendWhatsapp;

            ////notify -= SendSms;

            ////notify("order placed");
            ////notify = Order.SendEmail;

            ////notify("Email: order confirmed");

            //Order order = new Order(notify);
            //order.MakeOrder("PC", 50000);


            // 

            //Invoice("noor", 5000, EmpDiscount);
            //Invoice("marim", 10000, VipDiscount);
            //Invoice("abdo", 1000, VipNormal);

            // void - result - bool
            // Action -> void
            // Func -> last one in the return type
            //predicate -> bool

            //Action<string> hello = (msg) => Console.WriteLine(msg);
            //hello += SendEmail;
            //hello("hello");

            //Func<int,string> isEven = (num)=> num %2 == 0? "is even" : "is odd";
            //Console.WriteLine(isEven(5));

            List<int> nums = new List<int> {5,20,30};
            List<int> dividByFive = nums.Select(n => n/5).ToList();

            Predicate<int> isDividByfive = n => n % 5 == 0;

            Console.WriteLine(isDividByfive(6));

            //foreach(int divid in dividByFive)
            //{
            //    Console.WriteLine(divid);
            //}



        }

        public static void SendEmail(string msg)
        {
            Console.WriteLine($"Email:{msg}");
        }

        public static void SendSms(string msg)
        {
            Console.WriteLine($"SMS:{msg}");
        }

        public static void SendWhatsapp(string msg)
        {
            Console.WriteLine($"whats:{msg}");
        }



        public static void Invoice(string name, decimal amount, CalcDiscount discount)
        {
            decimal waybill = discount(amount);
            decimal saving =  amount - waybill;


            Console.WriteLine($"customr: {name}");
            Console.WriteLine($"original waybill:{amount}");
            Console.WriteLine($"waybill after discount:{waybill}");
            Console.WriteLine($"saving:{saving}");
        }


        public static decimal EmpDiscount(decimal price)
        {
            return price * .05m;
        }

        public static decimal VipDiscount(decimal price)
        {
            return price * .03m;
        }

        public static decimal VipNormal(decimal price)
        {
            return price * .01m;
        }

    }
}
