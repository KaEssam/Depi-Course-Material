using System.Collections;
using System.Numerics;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // self study (prop vs indexer, Generic Constraint )

            #region Indexer
            ////Days days = new Days();

            ////Console.WriteLine(days[1]);

            //Employee employee1 = new Employee() { Id = 1, Name="Ahmed", Role="BE", Salary = 5000 };
            //Employee employee2 = new Employee() { Id = 2, Name="Ali", Role="FE", Salary = 3000 };
            //Employee employee3 = new Employee() { Id = 3, Name="Nada", Role="UI UX", Salary = 100 };

            ////employee1[1] = "Ola";
            ////employee1["Name"] = "Amr";
            //Console.WriteLine(employee2["Name"]);

            #endregion

            #region Generic

            //ObjectBox objectBox = new ObjectBox();
            //objectBox.Id = "id";
            //objectBox.Id = 20;

            //Console.WriteLine((int)objectBox.Id);

            //Box<string> intBox = new Box<string>();

            //intBox.Id = 10;
            //intBox.Name = "40";

            //Console.WriteLine(sum("10", "10.5"));
            #endregion

            #region Collections

            //int[] nums = new int[2000000];


            //ArrayList array = new ArrayList();

            //array.Add("abc");
            //array.Add(10);
            //array.Add(true);

            //int x = (int)array[0];
            //string str = (string)array[2];

            //List<int> ints = new List<int>();
            //ints.Add(10);
            ////ints.Add("10");
            //List<Box<int>> boxes = new List<Box<int>>();

            //Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

            //keyValuePairs.Add(1, "ali");
            //keyValuePairs.Add(2, "ali");

            //Queue<string> orders = new Queue<string>();

            //orders.Enqueue("order 1");
            //orders.Enqueue("order 2");
            //orders.Enqueue("order 3");
            //orders.Enqueue("order 4");

            //Console.WriteLine(orders.Dequeue());
            //Console.WriteLine(orders.Peek()); //


            //Stack<int> stackInt = new Stack<int>();

            //stackInt.Push(1);
            //stackInt.Push(2);
            //stackInt.Push(3);

            //Console.WriteLine(stackInt.Pop());//3
            //Console.WriteLine(stackInt.Peek());//2

            //HashSet<int> set = new HashSet<int>();
            //set.Add(1);
            //set.Add(1);
            //set.Add(2);
            //set.Add(4);
            //set.Add(item: 4);

            //Console.WriteLine(set.Count);//

            #endregion

            #region Nullable Type

            //int? value = 10;

            //if (value.HasValue)
            //{
            //    Console.WriteLine(value);
            //}
            //else
            //{
            //    Console.WriteLine("dont have value");
            //}


            ////
            //int hasValue = value ?? 0;
            //Console.WriteLine(hasValue);

            #endregion

            // var dynamic
            //var y =10;
            //var x = "10";
            //x = 10;

            //dynamic x = 10;
            //x = "10";

        }

        //public static T sum<T>(T num1, T num2) where T : INumber<T>
        //{
        //    return num1 - num2;
        //}

        //public static int sum(int num1, int num2)
        //{
        //    return num1 + num2;
        //}

        //public static double sum(double num1, double num2)
        //{
        //    return num1 + num2;
        //}
    }


    //class Days
    //{
    //    private int[] days = { 31, 28, 30, 30, 31, 30, 29, 30, 30, 31, 30, 31 };

    //    public int this[int index]
    //    {
    //        get { return days[index - 1]; }
    //        set { days[index - 1] = value; }
    //    }
    //}
}
