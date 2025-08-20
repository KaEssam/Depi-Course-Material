using System.Collections;
using System.Numerics;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region indexer


            //StudentOld student = new StudentOld();

            //student.SetGrade("Ahmed", 20);
            //student.SetGrade("Ali", 20);
            //Console.WriteLine(student.GetGrade("Ali"));
            ////Console.WriteLine(student.GetGrade("Ahmed"));

            //foreach(StudentOld s in student)
            //{

            //}

            //student["ali"] = 10;
            //int[] arr = { 1, 2, 3, 4, 5 };
            ////Console.WriteLine(arr[1]);


            //Student student = new Student();

            //student[0] = "ahmed";
            //student[1] = "ali";

            //Console.WriteLine(student[0]);
            //Console.WriteLine(student[1]);

            //student.Students = {"Ahmed","ali"}; //error

            #endregion

            #region generic
            //List<int> ints = new List<int>();

            //ObjBox obj = new ObjBox();
            //obj.values = "adsda";
            //Console.WriteLine((int)obj.values);
            //obj.values = 1;
            //Console.WriteLine((int)obj.values);

            //Box<int> box = new Box<int>();
            //box.Value = 10;

            //Box<string> box1 = new Box<string>();
            //box1.Value = "10";
            //Console.WriteLine(box1.Value);

            //Console.WriteLine(sum((int)10.50,20));
            //Console.WriteLine(sum("20","10"));
            #endregion

            //int[] arr = new int[10];

            //ArrayList list = new ArrayList();
            //list.Add(10);
            //list.Add("10");
            //list.Add(true);

            //Hashtable

            //List<int> ints = new List<int>();
            //ints.Add(10);
            ////ints.Add(10.50);
            ////ints.Add(true);
            //ints.Remove(10);
            //ints.Clear();
            //ints.Sort();

            //Dictionary<int, string> emps = new Dictionary<int, string>();
            //emps.Add(1, "ali");
            //emps.Add(2, "ali");

            ////Console.WriteLine(emps[1]);

            //Stack stack = new Stack();
            //stack.Push("ss");
            ////Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Peek());
            ////stack.Pop();

            //Stack<int> ints1 = new Stack<int>();


            //Queue<int> ints2 = new Queue<int>();
            //ints2.Enqueue(10);
            //Console.WriteLine(ints2.Dequeue());

            //HashSet<int> ints3 = new HashSet<int>() { 1,2,3,3,4,6,6};
            //Console.WriteLine(ints3.Count);





            int? hasIntValue = 10;

            //if (hasIntValue.HasValue)
            //{
            //    Console.WriteLine($"value is {hasIntValue}");
            //}
            //else
            //{
            //    Console.WriteLine("u dont have value");
            //}

            //int intvalue = hasIntValue ?? 0;

            //Console.WriteLine(intvalue);



            // var , dynamic

            //var x = 10;

            //x = "";

            dynamic x = 10;

            x = "";
            Console.WriteLine(x);
        }

        //public static T sum<T>(T num1, T num2) where T : INumber<T>
        //{
        //    return num1 - num2;
        //}


        ////public static int sum(int num1, int num2)
        ////{
        ////    return num1 + num2;
        ////}


        ////public static double sum(double num1, double num2)
        ////{
        ////    return num1 + num2;
        ////}
    }


}
