namespace Day2
{
    internal class Program
    {
        public delegate double OpDelegate(double num1, double num2);
        public delegate void del(string msg);
        static void Main(string[] args)
        {

            //self study (xml doucmention )
            #region Extension Method

            //string name = "Amr Khaled";

            //Console.WriteLine(name.Length);
            //Console.WriteLine(name.IsLongerThan(5));
            //Console.WriteLine(name.IsLongerThan(5));

            //name.Print();

            //Console.WriteLine(StringExtensions.IsLongerThan(name,15));

            //int x = 20;
            //Console.WriteLine(x.IsLongerThan);

            //x.Print();


            //string Email = "dada@fafas";

            //Console.WriteLine(Email.IsValidEmail());

            //Console.WriteLine();

            #endregion 

            #region Delegate

            //Console.WriteLine(Operation(10,30,'+'));
            //Console.WriteLine(Operation(10,30,'-'));

            //Console.WriteLine(Add(20,50));
            //Console.WriteLine(divid(20,50));

            //OpDelegate op = Add;
            //Console.WriteLine(op(20, 30));

            //op += divid;

            //Console.WriteLine(op(20, 30));


            //del msg = Print;
            //msg += Loger;
            //msg += Loger;
            //msg += Print;

            //msg("Ahmed");


            //

            //var y = Add;

            //var add = delegate (int num1, int num2)
            //{
            //    return num1 + num2;
            //};


            //var add = (int num1, int num2) => num1 + num2;

            //Console.WriteLine(add(10,20));

            // ACTION, FUNC, PREDICATE


            // action => void
            //Action<string> print = (string msg) => Console.WriteLine($"Print: {msg}");

            //Action<string> log = Loger;

            //print("ali");
            //log("abdo");

            // FUNC => RETURN TYPE

            //Func<double, double, double> divid = (num1, num2) => num1 / num2;

            //Console.WriteLine(divid(20,40));

            //Predicate => boolan

            //Predicate<int> isEven = x => x % 2 == 0;

            //Console.WriteLine(isEven(5));
            //Console.WriteLine(isEven(6));
            #endregion


            #region Event

            //Account account = new Account() { Name = "Karim" };

            //account.transaction += SendSms;
            //account.transaction += SendEmail;

            //account.transaction = null;


            ////account.TransactionHandlerEvent += SendSms;
            ////account.TransactionHandlerEvent += SendEmail;

            ////account.TransactionHandlerEvent += null;

            //account.Deposit(2000);
            //account.Withdraw(500);


            //Notification notification = new Notification();

            //notification.notification += SendSms;
            //notification.notification += SendEmail;
            //notification.notification = null;

            //notification.NotificationDelEvent += SendSms;
            //notification.NotificationDelEvent -= SendEmail;
            //notification.NotificationDelEvent += null;

            //notification.UserAction("login");



            #endregion





        }


        public static void SendSms(string msg) => Console.WriteLine($"[sms]: {msg}");
        public static void SendEmail(string msg) => Console.WriteLine($"[email]: {msg}");


        public static void Print(string msg) => Console.WriteLine($"Print: {msg}");
        public static void Loger(string msg) => Console.WriteLine($"Log: {msg}");


        public static double Add(double num1, double num2) => num1 + num2;
        public static double divid(double num1, double num2) => num1 / num2;

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
