using static Day2.NotifcationSystem;

namespace Day2
{
    internal class Program
    {

        // self study (xml doucmention)
        public delegate double OpDelelage(double num1, double num2);

        public delegate void msgDel(string msg);
        static void Main(string[] args)
        {
            #region Extension Method

            // int x = 10;
            // //Console.WriteLine(x.IsLongerThan());
            // //Console.WriteLine(ExtensionMethods.IsEven(x));

            //x.Print();
            // //Console.WriteLine(x.IsEven());

            // var name = "karim";
            // string name2 = "KARIM";

            // name.Print();

            //Console.WriteLine(name.ToCapitlized());
            //Console.WriteLine(name2.ToCapitlized());

            //Console.WriteLine(name.IsLongerThan(4));

            #endregion

            #region Delegate

            //Console.WriteLine(Operation(20,30,'/'));
            //Console.WriteLine(Divid(20,30));


            //OpDelelage op = Divid;
            //Console.WriteLine(op(20, 40));
            //op += Mul;
            //Console.WriteLine(op(20, 40));

            //msgDel msg = Print;
            //msg += Log;
            //msg += Log;
            //msg -= Print;

            //msg("Karim");


            //var products = new List<Product>() 
            //{
            //    new Product {Name = "Iphone", Price = 2000,Discount = 200},
            //    new Product {Name = "Hp", Price = 100, Discount = 20},
            //    new Product {Name = "Nokia", Price = 1000,Discount =10},
            //};

            //var lowProduct = Product.filter(products, p => p.Price > 1000);
            ////var lowProduct = Product.filter(products, );

            //var total = products.Sum(p => p.Price);
            //Console.WriteLine(total);

            //var discount = products.Sum(p => p.Discount);
            //Console.WriteLine(discount);

            //var revenu = total - discount;
            //Console.WriteLine(revenu);




            //foreach(var p in lowProduct)
            //{
            //    Console.WriteLine(p.Name);
            //}


            ////var x = delegate (int x, int y)
            ////{
            ////    return x + y;
            ////};

            //var x = (int x, int y) => x + y;

            //var isEven = (int x) => x % 2 == 0;

            ////Console.WriteLine(x(10,20));

            ////Console.WriteLine(isEven(15));

            //var y = Print;

            //// action => void

            //Action<string> msg = msg => Console.WriteLine(msg);


            //// func => return type

            //Func<double, double, double> add = (num1, num2) => num1 + num2;

            ////Predicate => bool

            //Predicate<int> isOdd = x => x % 2 == 1;

            #endregion

            #region Event

            var account = new Account() { Name = "Baraa" };

            //account.transaction = SendSms;
            //account.transaction += SendEmail;
            //account.transaction = null;

            //account.TransactionDelegateEvent += SendSms;
            //account.TransactionDelegateEvent -= SendEmail;
            //account.TransactionDelegateEvent += null;


            var sms = new Notify();
            var log = new Logger();

            //subscribe
            account.onTransaction += sms.SendSms;
            account.onTransaction += log.Log;

            account.Deposit(2000);
            account.Withdraw(200);


            #endregion
        }

        public static void SendSms(string msg) => Console.WriteLine($"[SMS] {msg}");
        public static void SendEmail(string msg) => Console.WriteLine($"[Email] {msg}");

        public static void Print(string msg) => Console.WriteLine($"Print: {msg}");
        public static void Log(string msg) => Console.WriteLine($"Log: {msg}");

        public static double Divid(double num1, double num2) => num1 / num2;
        public static double Mul(double num1, double num2) => num1 * num2;

        public static double Operation(double num1, double num2, char op)
        {
            if (op == '*')
            {
               return num1* num2;
            }
            else if (op == '/')
            {
                return num1 / num2;
            }
            else
            {
                return 0;
            }
        }
    }
}
