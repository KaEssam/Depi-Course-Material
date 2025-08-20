using System.Collections;
using System.Numerics;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // self study (prop vs indexer,Generic Constriants)


            #region Indexer

            //year year = new year();
            //Console.WriteLine(year[1]);
            //year[1] = 20;

            //Console.WriteLine(year[1]);


            //Student student = new Student() { Id = 1, GPA = 3.5, Name = "Ahmed" };
            //Student student2 = new Student() { Id = 2, GPA = 2.5, Name = "Maha" };
            //Student student3 = new Student() { Id = 3, GPA = 1.5, Name = "Ali" };

            //Console.WriteLine(student[3]);
            //Console.WriteLine(student["Name"]);

            #endregion

            #region Generic

            //IntBox intBox = new IntBox();
            //intBox.Id = 10;


            //Box<int> box = new Box<int>();
            //box.id = 10;
            //box.printT(box.id);

            //Box<bool> box1 = new Box<bool>();

            //Box<string> box2 = new Box<string>();


            //Console.WriteLine(sum("20.50","15"));

            #endregion

            #region Collections

            //int[] arr = new int[100];

            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(10);
            //arrayList.Add("true");
            //arrayList.Add(true);

            //Console.WriteLine((int)arrayList[0]);
            //Console.WriteLine((int)arrayList[1]);
            //Console.WriteLine((int)arrayList[2]);

            //List<int> ints = new List<int>();

            //ints.Add(10);
            //ints.Add("10");
            //ints.Add(true);
            //ints.Add(10.50);

            //Console.WriteLine(ints.Count);


            //Dictionary<int, string> epms = new Dictionary<int, string>();
            //epms.Add(1, "Ahmed");
            //epms.Add(2, "Ali");

            //Dictionary<int, Student> stds = new Dictionary<int, Student>();

            ////var std = new Student() { Id = 20, Name = "ali" };


            //stds.Add(1, new Student() { Id = 10, Name = "ali", GPA = 2.5 });
            ////stds.Add(1, std);

            //Console.WriteLine(stds[1].Name);

            //HashSet<int> ints1 = new HashSet<int>() { 1,2,3,4,5,5,7,8};
            //Console.WriteLine(ints1.Count());

            //Queue<int> queu1 = new Queue<int>();

            //queu1.Enqueue(1);
            //queu1.Enqueue(2);
            //Console.WriteLine(queu1.Dequeue());
            //Console.WriteLine(queu1.Peek());

            //Stack<int> stacks = new Stack<int>();

            //stacks.Push(10);
            //stacks.Push(20);

            //Console.WriteLine(stacks.Pop());
            //Console.WriteLine(stacks.Peek()); //10





            #endregion

            #region nullable types

            //int? x=10;

            //if (x.HasValue)
            //{
            //    Console.WriteLine(x);
            //}
            //else
            //{
            //    Console.WriteLine("dont have value");
            //}


            ////null coalec op
            //int value = x ?? 0;
            //Console.WriteLine(value);

            #endregion

            ////var x = "10.50";
            ////x = 10;

            //var ints = new List<int>();

            //object x = "10.50";
            //x = 10;

            //Console.WriteLine(x.GetType());
        }

        //public static double sum(double n1, double n2)
        //{
        //    return n1 + n2;
        //}

        //public static T sum<T>(T n1, T n2) where T : INumber<T>
        //{
        //    return n1 - n2;
        //}
    }


    //public class year
    //{
    //    private int[] months = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

    //    public int this[int index]
    //    {
    //        get { return months[index-1]; }
    //        set { months[index-1] = value; }
    //    }
    //}
}
