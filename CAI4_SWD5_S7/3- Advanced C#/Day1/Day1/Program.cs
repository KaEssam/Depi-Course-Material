using System.Numerics;

namespace Day1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //Student student = new Student();

            ////Console.WriteLine(student.getName(2));
            ////configratin["ConnectionString"]
            ////request.query["name"]
            //Console.WriteLine(student["nor"]);
            //student["noor"] = 0;
            //Console.WriteLine(student["noor"]);

            //PrintInt printInt = new PrintInt();
            //printInt.Value = 1;
            ////printInt.Value = "";
            //printInt.Print();

            //PrintString printString = new PrintString();
            //printString.Value = "hello";
            ////printString.Value = 23123;
            //printString.Print();

            //PrintObj printObj = new PrintObj();
            //printObj.Value  = 1;
            //printObj.Value = "sdada";
            //printObj.Print();


            //Print<int> print = new Print<int>();
            //print.Value = 10;


            //Print<string> print1 = new Print<string>();
            //print1.Value = "sss";

            //Print<PrintInt> print = new Print<PrintInt> ();

            //print.PrintValue();

            //Print<PrintString> print1 = new Print<PrintString> ();
           

            int? x = 20;

            if (x.HasValue)
            {
                Console.WriteLine( x.Value);
            }
            else
            {
                Console.WriteLine("no value");
            }

            int value = x ?? 0;
            Console.WriteLine(value);
        }

        public static T Sum<T>(T x, T y) where T : INumber<T>
        {
            return x + y; 
        }
    }
}
