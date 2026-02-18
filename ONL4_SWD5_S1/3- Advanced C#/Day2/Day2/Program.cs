namespace Day2
{
    delegate void notifyDelegate(string msg);
    delegate decimal discountDel(decimal amount);
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");


            //string email = "kaessam@hotmail.com";
            //email.IsValidEmail();
            ////Console.WriteLine(StringHelper.IsValidEmail(email));

            //string res = email.Captialize().IsValidEmail() ? "email is valid" : "email not valid";

            //Console.WriteLine(res);


            //string name = "karim";
            //Console.WriteLine(name.Captialize());


            // Deglegte




            //notifyDelegate notify;
            //notify = sendEmail;
            //notify += sendSms;
            //notify += sendWhats;
            ////notify -= sendEmail;

            ////notify("helli");

            //order("PC", 5000,notify);

            //invoice("moaz", 5000, VipDiscount);
            //Console.WriteLine("=========================");
            //invoice("nada", 5000, EmpDiscount);
            //Console.WriteLine("=========================");
            //invoice("ali", 5000, Discount);

            // action => void
            // func => return type
            //perdicate => bool

            //Action<string> notification = (msg) => Console.WriteLine(msg);
            //notification("hello");
            //notification("bye");
            //notification += sendEmail;

            //List<string> list = new List<string>() {"ali","noor","ahmed"};

            //list.ForEach(i => Console.WriteLine(i));

            //Func<int, int> dividByFive = num => num / 5;

            //Console.WriteLine(dividByFive(20));

            //List<int> nums = new List<int>() { 5,4,10,8,9};

            //List<int> ints = nums.Select(n=>n*5).ToList();

            //ints.ForEach(n => Console.WriteLine(n));


            Predicate<int> iseven = i => i%2 == 0;

            Console.WriteLine(iseven(6));
        }


        public static void order(string product, decimal price,notifyDelegate msg)
        {
            Console.WriteLine($"order placed: {product} - {price}");
            msg.Invoke($"$order placed: {product} - {price}");
            //sendEmail($"order placed: {product} - {price}");
            //sendSms($"order placed: {product} - {price}");
            
        }

        public static void sendEmail(string msg)
        {
            Console.WriteLine($"Email: {msg}");
        }

        public static void sendSms(string msg)
        {
            Console.WriteLine($"Sms: {msg}");
        }

        public static void sendWhats(string msg)
        {
            Console.WriteLine($"sendWhats: {msg}");
        }


        //


        public static void invoice(string customerName, decimal amount,discountDel discount)
        {
            decimal final = discount(amount);
            decimal saved = amount - final;

            Console.WriteLine($"{customerName}");
            Console.WriteLine($"Total: {amount}");
            Console.WriteLine($"final: {final}");
            Console.WriteLine($"saved: {saved}");
        }
        public static decimal EmpDiscount(decimal price)
        {
            return price * .05m;
        }


        public static decimal VipDiscount(decimal price)
        {
            return price * .07m;
        }

        public static decimal Discount(decimal price)
        {
            return price * .01m;
        }
    }
}
 