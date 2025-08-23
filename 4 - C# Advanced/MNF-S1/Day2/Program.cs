using System.Threading.Channels;

namespace Day2
{
    internal class Program
    {
        public delegate double OpDelegate(double num1, double num2);

        public delegate void del(string msg);

        static void Main(string[] args)
        {

            #region Extensions Method
            //self study (xml documention)

            //string name = "Ali";

            //Console.WriteLine(StringExtensions.IsLongerThan(name,3));
            //Console.WriteLine(name.IsLongerThan(3));

            //name.Print();

            //int x = 10;

            //x.Print();

            //string email = " ";
            //Console.WriteLine(email.IsValidEmail());

            #endregion

            #region Delegate


            ////var test = Print("HELLO"); 
            //var test = Add(10,20);

            //Console.WriteLine(test);
            ////Console.WriteLine(Operation(20,50,'+'));
            ////Console.WriteLine(Add(20,80));

            ////OpDelegate op = Add;
            ////op += min;
            ////op += Add;
            ////op -= Add;

            ////Console.WriteLine(op(20,50));

            //del del = Print;

            //del de2 = Log;
            ////del += Log;
            ////del += Print;

            ////del("ahmed");




            //var x = delegate (int x, int y) { return x + y; };
            //var x1 = delegate (int x) { Console.WriteLine(x); };

            ////var x = (int x, int y) => x + y;


            //Action<string> print = delegate (string msg) { Console.WriteLine($"print{msg}"); };

            //Action<string> print1 = (string msg) =>  Console.WriteLine($"print{msg}");


            //Func<int, int, double> add = (num1, num2) => num1 + num2;

            //Console.WriteLine(add(20,30));

            //Func<string, int> nameLen = (s) => s.Length;

            //Console.WriteLine(nameLen("aya"));

            //Predicate<int> isEven = (x) => x % 2 == 0;
            //var isEven1 = delegate (int x) { return x % 2 == 0; };

            //Console.WriteLine(isEven(5));
            //Console.WriteLine(isEven(6));

            //Console.WriteLine(x(10,20));


            #endregion

            #region Event

            //var sys = new Notification();

            //sys.NotifyDelEvent += EmailNotification;
            //sys.NotifyDelEvent += SmsNotification;

            //sys.NotifyDelEvent += null;

            //sys.UserActtion("Sign up");


            Account account = new Account() { Name = "Karim", Balance = 1000 };

            //account.trancHandler = sendSms;

            //account.trancHandler = null;

            //account.Deposit(100);
            //account.Withdraw(500);


            account.TrancHandlerEvent += sendSms;

            account.TrancHandlerEvent += null;

            account.Deposit(100);
            account.Withdraw(500);


            #endregion


        }


        public static void sendSms(string sms) => Console.WriteLine($"[SMS]: {sms}");

        public static void EmailNotification(string msg) => Console.WriteLine($"Email sent: {msg}");
        public static void SmsNotification(string msg) => Console.WriteLine($"Sms sent: {msg}");


        public static void Print(string msg) => Console.WriteLine($"{msg}");
        public static void Log(string msg) => Console.WriteLine($"Log: {msg}");
        public static void MSG(string msg) => Console.WriteLine($"MSG: {msg}");
        

        public static double Add(double num1, double num2) => num1 + num2;
        public static double min(double num1, double num2) => num1 - num2;
        

        public static double Operation(double num1, double num2, char op)
        {
            if(op == '+')
            {
                return num1 + num2;
            }
            else if(op == '-')
            {
                return num1 - num2;
            }
            else
            {
                return 0;
            }
        }
    }
}
