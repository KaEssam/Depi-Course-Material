using System.Threading.Tasks;

namespace Day3
{
    internal class Program
    {

        static readonly object _lock = new object();
        static async Task Main(string[] args)
        {

            #region Recap
            //Order Processing

            //var order = new Order() { SubTotal = 1000 };

            //if (order.SubTotal >= 1000)
            //{
            //    order.Shipping = 0;
            //}
            //else
            //{
            //    order.Shipping = 70;
            //}

            //if (order.SubTotal >= 1000)
            //{
            //    order.Discount = order.SubTotal * 0.1m;
            //}

            //order.Shipping = order.SubTotal >= 1000 ? 0 : 30;

            //DicountRule discountRule = HighDiscount;
            //discountRule += HighShipping;
            //discountRule += VipDiscount;
            //discountRule += FirstOrderDiscount;

            //discountRule(order);

            ////decimal totalDiscount = 0;
            ////foreach(DicountRule rule in discountRule.GetInvocationList())
            ////{
            ////    totalDiscount += discountRule(order);
            ////} 

            ////order.Discount = totalDiscount;

            //Console.WriteLine($"Total: {order.Total}");


            //var nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var greaterThan5 = Filter(nums, n => n < 5);
            //var isEvenNums = Filter(nums, isEven);

            ////foreach(var x in greaterThan5)
            ////{
            ////    Console.WriteLine(x);
            ////}

            //foreach (var x in isEvenNums)
            //{
            //    Console.WriteLine(x);
            //}

            //foreach (var x in nums)
            //{
            //    var res = isEven(x);
            //    Console.WriteLine(x);
            //}

            #endregion

            #region Error Handling (try .. catch.. final)

            //int x = 5;
            //int y = 0;
            //int z = x / y;

            //Console.WriteLine(z);



            //try
            //{
            //    Console.Write("Enter Number: ");
            //    int num = int.Parse(Console.ReadLine()); //abc

            //    int res = 100 / num;

            //    Console.WriteLine(value: $"Result: {res}");
            //}
            //catch (DivideByZeroException)
            //{

            //    Console.WriteLine("cannot divid by zero");
            //}
            //catch (FormatException)
            //{
            //    throw new Exception ("invalid format number");
            //}

            //Console.WriteLine(value: "end");
            //Console.WriteLine("end");
            //Console.WriteLine("end");
            //Console.WriteLine("end");

            //try
            //{
            //    Console.Write("Enter Number 1: ");
            //    int num1 = int.Parse(Console.ReadLine());

            //    Console.Write("Enter Number 2: ");
            //    int num2 = int.Parse(Console.ReadLine());

            //    int res = divid(num1, num2);
            //    Console.WriteLine(res);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.StackTrace);
            //    Console.WriteLine(ex.InnerException);
            //}
            //finally
            //{
            //    Console.WriteLine("finall here");
            //}


            //Console.WriteLine(value: "end");
            //Console.WriteLine("end");
            //Console.WriteLine("end");
            //Console.WriteLine("end");

            #endregion

            //Thread T1 = new Thread(DoWork);
            //Thread T2 = new Thread(DoWork);

            //T1.Start();
            //T2.Start();

            //Console.WriteLine("start");
            //Thread T3 = new Thread(work1);
            //Thread T4 = new Thread(work2);
            //T3.IsBackground = true;
            //T3.Start();
            ////T4.Start();

            //Console.ReadKey();

            //T3.Join();
            //T4.Join();



            //DoWork();
            //DoWork();

            //work1();
            //work2();

            /////////////////////////////////
            // TAP 


            // Console.WriteLine("start");
            //string res = await GetData();//15 min 
            // Console.WriteLine(res);

            // Console.WriteLine("end");

            var t1 = work1();
            var t2 = work2();

            Task[] tasks = new[] { t1, t2 };

            //await Task.WhenAll(tasks);

            foreach(var t in tasks)
            {
                Console.WriteLine($"Task Id: {t.Id}, status: {t.Status}");
            }
        }



        public static async Task work1()
        {

            for (var i = 0; i <= 1000; i++)
            {
                lock (_lock)
                {
                    Thread.Sleep(50);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                await Task.Delay(100);
            }


        }

        public static async Task work2()
        {
            for (var i = 1001; i <= 2000; i++)
            {

                lock (_lock)
                {
                    Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                await Task.Delay(10);

            }
        }


        public static Task<string> GetData()
        {
          return  Task.Run(() =>
            {
                Thread.Sleep(5000);
              return "data";
            });

            

        }



        public static void DoWork()
        {
            Thread.Sleep(3000);
            Console.WriteLine("work Done");
        }
        //public static void work1()
        //{
                
        //    for (var i = 0; i <= 1000; i++)
        //    {
        //        lock (_lock)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine(i);
        //            Console.ForegroundColor = ConsoleColor.White;
        //        }
        //    }
            
            
        //}

        //public static void work2()
        //{
        //    for (var i = 1001; i <= 2000; i++)
        //    {

        //        lock (_lock)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Green;
        //            Console.WriteLine(i);
        //            Console.ForegroundColor = ConsoleColor.White;
        //        }

        //    }
        //}

        //public static int divid(int num1, int num2)
        //{
        //    //if (num2 == 0)
        //    //    throw new Exception("Cannot divid by zero");

        //    return num1 / num2;
        //}

        //public static decimal HighDiscount(Order order)
        //{
        //    if (order.SubTotal >= 1000)
        //    {
        //        return order.Discount = order.SubTotal * 0.1m;
        //    }
        //    return 0;
        //}


        //public static decimal HighShipping(Order order)
        //{
        //    if (order.SubTotal >= 1000)
        //    {
        //        return order.Shipping = 0;
        //    }
        //    else
        //    {
        //        return order.Shipping = 70;
        //    }
        //}


        //public static decimal VipDiscount(Order order)
        //{
        //    return 30;
        //}

        //public static decimal FirstOrderDiscount(Order order)
        //{
        //    return 10;
        //}

        //public static List<int> Filter(List<int> nums, Predicate<int> predicate)
        //{
        //    var res = new List<int>();
        //    foreach (var x in nums)
        //    {
        //        if (predicate(x))
        //        {
        //            res.Add(x);
        //        }
        //    }
        //    return res;

        //}

        //public static bool isEven(int num) => num % 2 == 0;

    }
}

