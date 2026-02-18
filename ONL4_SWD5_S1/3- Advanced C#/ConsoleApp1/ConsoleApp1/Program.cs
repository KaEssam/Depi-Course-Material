using System.Collections;
using System.Numerics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            //Console.WriteLine(student.GetStudnt(0));
            //student[0]

            //student.num = 1;

            Console.WriteLine(student[1]);

            student["st1"] = "ahmed";
            //Console.WriteLine(student[2]);
            Console.WriteLine(student["st1"]);
            //Console.WriteLine(student[2]);


            // IntBox box = new IntBox();
            // box.Box = "1";

            // StringBox stringBox = new StringBox();
            // stringBox.Box = "2";


            // ObjBox objBox = new ObjBox();
            // objBox.Box = "3";

            //ObjBox objBox1 = new ObjBox();
            // objBox1.Box = 4;
            // int x = (int)objBox1.Box;


            //Box<int> box = new Box<int>();
            //box.box = 1;

            //Box<string> box2 = new Box<string>();

            //Emp emp = new Emp()
            //{
            //    Name = "Karim"
            //};

            //AuditService<Emp> auditService = new AuditService<Emp>();
            //auditService.printT(emp);

            //Add<double>(220, 20);

            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(student);
            //arrayList.Add(1);
            //arrayList.Add("sdas");
            //arrayList.Add(true);
            //arrayList.Add(1.54);


            //int[] ints = new int[5];
            //ints[0] = 1;
            //ints[1] = 1;
            //ints[2] = 1;
            //ints[3] = 1;
            //ints[4] = 1;
            //ints[5] = 1;
            //ints[6] = 1;
            //ints[7] = 1;
            //ints[8] = 1;
            ////ints[0] = "1";

            ////List<int> ints1 = new List<int>();
            ////ints1.Add(1);

            //Dictionary<int,string> keyValuePairs = new Dictionary<int,string>();

            //keyValuePairs.Add(1, "Karim");
            //keyValuePairs.Add(1, "Karim");
            //keyValuePairs.Add(1, "Karim");


            //Console.WriteLine(keyValuePairs[1]);


            //Emp emp = new Emp();
            //emp.Name = null;

            int? x = null;

            if (x.HasValue)
            {
                Console.WriteLine(x.Value);
            }
            else
            {
                Console.WriteLine("Dont have value");
            }

            int defaultX = x ?? 0;
            Console.WriteLine(defaultX);
        }

        public static T Add<T>(T x, T y) where T : INumber<T>
        {
            return x + y;
        }
    }


}
