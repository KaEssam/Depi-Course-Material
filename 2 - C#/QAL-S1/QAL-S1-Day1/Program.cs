namespace QAL_S1_Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region console
            /*
            Console.Title = "C# DAY1";
            Console.WriteLine("Hello QAL");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("Hello QAL");
            Console.ResetColor(); 
            Console.WriteLine("Hello QAL");
            Console.WriteLine("Hello QAL");
            Console.WriteLine("Hello QAL");
            Console.WriteLine("Hello QAL");
            Console.WriteLine("Hello QAL");
            Console.WriteLine("Hello QAL");
            Console.WriteLine("Hello QAL");


            Console.ReadKey();
            */
            #endregion

            #region Declartion 

            //int x = 10;
            //int @int = 10;


            //Console.WriteLine(sizeof(int));
            //Console.WriteLine(sizeof(uint));

            //Console.WriteLine(sizeof(long));
            //Console.WriteLine(sizeof(ulong));
            //Console.WriteLine(sizeof(double));
            //Console.WriteLine(sizeof(float));
            //Console.WriteLine(sizeof(short));
            //Console.WriteLine(sizeof(decimal));
            //Console.WriteLine(sizeof(bool));



            //Console.WriteLine(int.MinValue);
            //Console.WriteLine(int.MaxValue);
            //Console.WriteLine("--------------------------------");

            //Console.WriteLine(uint.MinValue);
            //Console.WriteLine(uint.MaxValue);
            //Console.WriteLine("--------------------------------");

            //Console.WriteLine(long.MinValue);
            //Console.WriteLine(long.MaxValue);
            //Console.WriteLine("--------------------------------");

            //Console.WriteLine(ulong.MinValue);
            //Console.WriteLine(ulong.MaxValue);
            //Console.WriteLine("--------------------------------");

            //Console.WriteLine(decimal.MinValue);
            //Console.WriteLine(double.MaxValue);
            //Console.WriteLine(float.MaxValue);
            //Console.WriteLine("--------------------------------");

            //string firstName = "Karim";
            //string lastName = "Essam";

            //string fullName =firstName + ' ' + lastName;
            //Console.WriteLine(fullName);
            //string FullName = $"{firstName} {lastName}";
            //Console.WriteLine(FullName);

            //Console.WriteLine($"name in upper: { FullName.ToUpper()}");
            //Console.WriteLine($"name in lower: { FullName.ToLower()}");
            //Console.WriteLine($"length: { FullName.Length}");

            //Console.WriteLine(fullName.IndexOf('A',StringComparison.OrdinalIgnoreCase));

            //Console.WriteLine(fullName.Contains('A'));

            //Console.WriteLine(fullName.Replace("KaRim","marim"));

            //int[] y = [1, 2, 3, 4, 5];
            //Console.WriteLine(Array.IndexOf(y,6));


            #endregion

            #region User Input
            //ReadLine => karim => "karim" => string
            //Console.WriteLine("Enter your name: ");
            //string name = Console.ReadLine();
            //Console.WriteLine($"UR NAME IS : {name}");

            //Console.Write("Enter your age: ");
            //int age = Convert.ToInt32(Console.ReadLine());
            //Console.Write($"UR age : {age}");

            ////////////////////////
            ///
            //Read => "karim" => 'k' => ascii code
            //Console.WriteLine("Enter your name: ");
            //int name2 = Console.Read();
            //Console.WriteLine(name2);


            //Console.WriteLine("enter your first char");
            //int ch = Console.Read();
            //Console.WriteLine((char)ch);



            Console.WriteLine("ENTER ANY KEY:");
            char k1 = Convert.ToChar(Console.Read()); //a

            int k2 = (char)Console.Read(); //13


            int k3 = Console.Read();//10

            Console.WriteLine($"k1: {k1}"); 
            Console.WriteLine($"k2: {k2}");
            Console.WriteLine($"k3: {k3}");

            #endregion
        }
    }
}
