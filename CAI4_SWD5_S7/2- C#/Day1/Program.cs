using System.ComponentModel;

namespace Day1
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Recap

            //string 

            //string FirstName = "Karim";
            //string LastName = "Essam";

            //string FullName = FirstName+ " " + LastName;
            //string fullName = $"{FirstName} {LastName}";
            //Console.WriteLine(FullName);
            //Console.WriteLine(fullName);

            //Console.WriteLine(fullName.ToLower());
            //Console.WriteLine(fullName.ToUpper());
            //Console.WriteLine(fullName.Replace("e","c", StringComparison.OrdinalIgnoreCase));


            //input

            // read line
            //string x = Console.ReadLine();
            //Console.WriteLine(x);

            //read
            //char y = (char)Console.Read();
            //int z = Console.Read();
            //int v = Console.Read();
            //Console.WriteLine(z);
            //Console.WriteLine(v);
            //read key


            ////////////////////////////////
            /// CASTING
            ///////
            ///

            // IMPLICT

            //int X = 5;
            //double y = X;

            ////explicit 
            //double m = 5.5;
            //int z = (int)m;

            // Convert

            //string str = "123";
            //int x = Convert.ToInt32(str);
            //Console.WriteLine(x);

            //parse

            //string str = "123";
            //int x = int.Parse(str);
            //Console.WriteLine(x);

            //int[]x = { 5,4,8,1,7,9 };

            //x.Sort();
            //x.Reverse();
            ////Console.WriteLine(x[4]);
            //Console.WriteLine(x[1]);

            //int[] y = new int[10];
            //Array.Copy(x, y, 3);
            //Console.WriteLine(y[1]);


            #endregion


            //Console.WriteLine(add(1.5,5));


            //pass by value, pass by ref
            // ref , out, params

            // pass by value
            //int x = 10;
            //add5(ref x);
            //Console.WriteLine(x);

            //string str = "abc";

            //if(int.TryParse(str, out int res))
            //{
            //    Console.WriteLine(res);
            //}
            //else
            //{
            //    Console.WriteLine("invalid input");
            //}

            Console.WriteLine(add(1, 5, 6, 7, 8, 9, 7, 5));
        }


        public static void add5( ref int num)
        {
            num += 5;
            Console.WriteLine(num);
        }

        public static int add(int x, int y)
        {
            return x + y; 
        }

        public static double add(double x, int y)
        {
            return x + y;
        }

        public static int add(params int[] nums)
        {
            int sum = 0;
            foreach(int num in nums)
            {
                sum += num;
            }
            return sum;
        }
    }
}

