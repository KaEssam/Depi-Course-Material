namespace MNF_S1_Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Console

            //Console.Title = "C# Day1";
            //Console.BackgroundColor = ConsoleColor.DarkCyan;
            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("Hello, World!");
            //Console.ResetColor();
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("Hello, World!");
            //Console.ReadKey();


            #endregion

            #region Naming & Declar

            //int x = 5;
            //int @int = 5;
            //int num1 = 5;

            //string Y = "ahmed";

            //


            #endregion

            #region datatybe
            // int, double, long, float, decimal, uint,ulong

            //Console.WriteLine(sizeof(int));
            //Console.WriteLine(sizeof(long));
            //Console.WriteLine(sizeof(short));
            //Console.WriteLine(sizeof(double));
            //Console.WriteLine(sizeof(decimal));
            //Console.WriteLine(sizeof(float));
            //Console.WriteLine(sizeof(bool));

            //////////
            ///

            //Console.WriteLine(byte.MinValue);
            //Console.WriteLine(byte.MaxValue);
            //Console.WriteLine("=========================");

            //Console.WriteLine(int.MinValue);
            //Console.WriteLine(int.MaxValue);
            //Console.WriteLine("=========================");
            //Console.WriteLine(uint.MinValue);
            //Console.WriteLine(uint.MaxValue);
            //Console.WriteLine("=========================");
            //Console.WriteLine(long.MinValue);
            //Console.WriteLine(long.MaxValue);
            //Console.WriteLine("=========================");
            //Console.WriteLine(ulong.MinValue);
            //Console.WriteLine(ulong.MaxValue);
            //Console.WriteLine("=========================");
            //Console.WriteLine(decimal.MinValue);
            //Console.WriteLine(decimal.MaxValue);
            //Console.WriteLine("=========================");

            //Console.WriteLine(double.MinValue);
            //Console.WriteLine(double.MaxValue);
            //Console.WriteLine("=========================");

            //Console.WriteLine(float.MinValue);
            //Console.WriteLine(float.MaxValue);
            //Console.WriteLine("=========================");
            #endregion

            #region string

            //string FirstName = "Karim";
            //string LastName = "Essam";

            ////string fullName = FirstName + ' ' + LastName;
            ////Console.WriteLine(fullName);

            //string FullName = $"{FirstName} {LastName}";
            //Console.WriteLine(FullName);

            //Console.WriteLine($"Name in Upper: {FullName.ToUpper()}");
            //Console.WriteLine($"Name in Lower: {FullName.ToLower()}");
            //Console.WriteLine($"Lenth: {FullName.Length}"); //10 //12
            //Console.WriteLine(FullName.Contains('A',StringComparison.OrdinalIgnoreCase));
            //Console.WriteLine(FullName.IndexOf('A')); // 
            //Console.WriteLine(FullName.Replace('A','e'));
            //Console.WriteLine(FullName.Replace("Karim","Ali"));
            #endregion

            #region user Input
            // ReadLine => 29 => "29" => string

            //Console.Write("Enter Your Name: ");
            //string userName = Console.ReadLine();

            //Console.Write("Enter Your age: ");
            //int age =Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine($"Your name is {userName}, age {age}");

            // Read() => int
            

            Console.Write("Enter key: ");
            char k1 = (char)Console.Read();//a
            Console.ReadLine();//13 
            char k2 = Convert.ToChar(Console.Read());//a
            Console.ReadLine();//10
            int k3 = Console.Read();

            Console.WriteLine($"k1: {k1}"); //a
            Console.WriteLine($"k2: {k2}"); //a 
            Console.WriteLine($"k3: {k3}"); //97

            #endregion
        }
    }
}
