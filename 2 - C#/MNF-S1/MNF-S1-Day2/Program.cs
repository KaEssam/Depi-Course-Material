using System.Collections;

namespace MNF_S1_Day2;

class Program
{
    static void Main(string[] args)
    {

        #region value Type & reference type
        //
        // int x = 5;
        // int y = x;
        //
        // Console.WriteLine(y); //5
        //
        // y = 20;
        // Console.WriteLine(y);//20
        // Console.WriteLine(x);//5
        //
        // int[] nums = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        // int[] data = nums;
        //
        // Console.WriteLine(nums[0]); //1
        // Console.WriteLine(data[0]); //1
        //
        // data[0] = 50;
        // Console.WriteLine(data[0]); //50
        // Console.WriteLine(nums[0]); //50

        #endregion

        #region boxing & unboxing

        // int x = 5;
        // object obj = x; // boxing
        //
        // int y = (int)obj; //unboxing
        //

        #endregion

        #region Type Casting

        // implicit casting => smaller to lager data type

        // int x = 20;
        //
        // double y = x;

        // explicit casting

        // double x = 20.50;
        //
        // int y = (int)x;

        // convert => all data types

        // string str = "abc";
        // int num = Convert.ToInt32(str);
        //
        // Console.WriteLine(num);

        // parse => numeric

        // string str = "abc";
        // int num = int.Parse(str);
        // Console.WriteLine(str);


        //###### =>>  try parse (self study) //rawan

        string num = "abc";
        if (int.TryParse(num, out int num2))
        {
            Console.WriteLine(num2);
        }
        else
        {
            Console.WriteLine("invalid");
        }

        #endregion

        #region operatores

        // math

        // int a = 10, b = 3;
        //
        // Console.WriteLine(a + b);  // 13
        // Console.WriteLine(a - b);  // 7
        // Console.WriteLine(a * b);  // 30
        // Console.WriteLine(a / b);  // 3
        // Console.WriteLine(a % b);  // 1

        //######
        // Comparison
        //######

        // int number = 10;
        // //
        // bool isLessThan = number < 10; //False
        // bool isGreaterThan = number > 10; // false
        // bool isEqualTo = number == 10; // true
        // bool isNotEqualTo = number != 10; //false
        // bool isGreaterThanOrEqualTo = number >= 10; //true
        // bool isLessThanOrEqualTo = number <= 10; //true
        //
        // Console.WriteLine(isLessThan);
        // Console.WriteLine(isGreaterThan);
        // Console.WriteLine(isEqualTo);
        // Console.WriteLine(isNotEqualTo);
        // Console.WriteLine(isGreaterThanOrEqualTo);
        // Console.WriteLine(isLessThanOrEqualTo);


        //##############
        // Logical
        //###############

        // bool isTrue = true;
        // bool isFalse = false;
        // bool result;
        //
        // // //&& true if both true
        // // result = isTrue && isFalse;
        // // Console.WriteLine(result); //false
        // //
        // // // || true if anyone true
        // // result = isFalse || isTrue;
        // // Console.WriteLine(result); //true
        // //
        // // ^ => false if both same
        //
        // result = isFalse ^ isTrue;
        // Console.WriteLine(result); // true
        //
        //
        // result = isFalse ^ isFalse;
        // Console.WriteLine(result); // false
        //
        // result = isTrue ^ isTrue;
        // Console.WriteLine(result); // false
        //
        //
        // //!
        // result = isTrue && !isFalse; //ture
        // Console.WriteLine(result); //false

        //###################
        // increment & decrement
        //#####################

        // int x = 10;
        //
        // Console.WriteLine(x); //10
        // Console.WriteLine(++x); //11 =>
        // Console.WriteLine(x); //11
        // Console.WriteLine(x++); //11
        // Console.WriteLine(x); //12
        //
        // Console.WriteLine(--x); //11
        // Console.WriteLine(x); //11
        // Console.WriteLine(x--); // 11
        // Console.WriteLine(x); //10


        //###################
        // assigmnet
        //###################

        // int a = 10;
        //
        // Console.WriteLine(a+=5);  // 15
        // Console.WriteLine(a-=4);  // 11
        // Console.WriteLine(a*=2);  // 22
        // Console.WriteLine(a/=10);  // 2.2 =>2
        // Console.WriteLine(a%=2);  // 0
        #endregion

        #region if.. else

        // if (false)
        // {
        //     Console.WriteLine("True");
        // }
        // else
        // {
        //     Console.WriteLine("false");
        // }

        // Console.Write("Enter Number: ");
        // int number = Convert.ToInt32(Console.ReadLine());

        // if (number % 2 == 0 )
        // {
        //     if (number == 0)
        //     {
        //         Console.WriteLine("Number is zero");
        //     }
        //     else
        //     {
        //         Console.WriteLine($"{number} is even");
        //     }
        // }
        // else
        // {
        //     Console.WriteLine($"{number} is odd");
        // }

        // if (number % 2 == 0 && number != 0 )
        // {
        //         Console.WriteLine($"{number} is even");
        // }
        // else if (number == 0)
        // {
        //     Console.WriteLine("Number is zero");
        // }
        // else
        // {
        //     Console.WriteLine($"{number} is odd");
        // }


        // if (number == 0)
        // {
        //     Console.WriteLine("Number is zero");
        // }
        // else if (number % 2 == 0)
        // {
        //         Console.WriteLine($"{number} is even");
        // }
        // else
        // {
        //     Console.WriteLine($"{number} is odd");
        // }

        #endregion

        #region ternery op

        // //syntax => condition ? true part: false part
        //
        // Console.Write("Enter Number: ");
        // int number = Convert.ToInt32(Console.ReadLine());
        //
        // string res =  number % 2 ==0? "even": "odd";
        // // string res =  number % 2 ==0 && number !=0 ? "even" : number == 0 ? "zero": "odd";
        // Console.WriteLine(res);
        #endregion

        #region switch
        //
        // int day = 1;
        //
        // if (day == 1)
        // {
        //     Console.WriteLine("Sat");
        // }
        // else if (day == 2)
        // {
        //     Console.WriteLine("Mon");
        // }
        // else if (day == 3)
        // {
        //     Console.WriteLine("Tue");
        // }
        // else if (day == 4)
        // {
        //     Console.WriteLine("Wed");
        // }
        // else
        // {
        //     Console.WriteLine("weekend");
        // }
        //
        //
        // switch (day)
        // {
        //     case 1:
        //     case 6:
        //         Console.WriteLine("sat");
        //         break;
        //     case 2:
        //         Console.WriteLine("sun");
        //         break;
        //     case 3:
        //         Console.WriteLine("tue");
        //         break;
        //     default:
        //         Console.WriteLine("Weekend");
        //         break;
        // }

        #endregion

        #region  loops

        // for => for(intial; condition; increment/decrement)

        // for (int i = 0; i <= 10; i++)
        // {
        //     Console.WriteLine(i);
        // }

        //foreach => foreach(type variable in array)

        // int[] nums = {1, 2, 3, 4, 5, 6, 7, 8, 9,10};
        //
        // foreach (int num in nums)
        // {
        //     Console.WriteLine(num);
        // }

        // while (condition) {code block}

        // int x = 20;
        //
        // while (x <= 30)
        // {
        //     Console.WriteLine(x);
        //     x++;
        // }
        //
        // do while

        // int x = 40;
        // do
        // {
        //     Console.WriteLine(x);
        //     x++;
        // } while (x < 40);


        //
        // for (int i = 0; i <= 10; i++)
        // {
        //     if(i == 5)
        //         break;
        //     Console.WriteLine(i);
        // }

        // for (int i = 0; i <= 10; i++)
        // {
        //     if(i == 5)
        //         continue;
        //     Console.WriteLine(i);
        // }
        #endregion

        #region array

        // int[] nums = new int[5] {1,2,3,4,5};
        // int[] nums2 = {1,2,3,4,5};
        // Console.WriteLine(nums2[5]);
        // Console.WriteLine(nums[0]);
        // nums[0] = 1;
        // Console.WriteLine(nums[0]);
        // nums[1] = 2;
        // nums[2] = 3;
        // nums[3] = 4;
        // nums[4] = 5;
        // // nums[5] = 6;
        //
        // // Console.WriteLine(nums[5]);
        //
        // Array.Resize(ref nums,10);
        // Console.WriteLine(nums[9]);
        // int[] copy = new int[20];
        // Array.Copy(nums,copy,4);
        // Console.WriteLine(copy[15]);
        //


        // char[,] letters = new char[2, 3]
        // {
        //     {'a','b','c'},
        //     {'a','b','c'},
        // };
        // // letters[0, 0] = 'A';
        //
        //
        // // Console.WriteLine(letters[2, 2]);
        // Console.WriteLine(letters.Length);
        // Console.WriteLine(letters.GetLength(1));

        // int[][] arr = new int[3][];  // Outer array has 3 elements
        //
        // arr[0] = new int[] { 1, 2, 3 };       // First row has 3 elements
        // arr[1] = new int[] { 4, 5 };          // Second row has 2 elements
        // arr[2] = new int[] { 6, 7, 8, 9 };    // Third row has 4 elements


        #endregion

        #region methods

        // access modifier static return type(void) name(params){code block}

        // hello();

        // Console.WriteLine(userInfo("karim", "Essam"));
        // Console.WriteLine(userInfo());

        #endregion

        #region Passing data

        //REF

        int x;

        // void addFive(ref int num)
        // {
        //     num += 5; //10
        // }

        // addFive(ref x);
        // System.Console.WriteLine(x);

        // //out
        // string name;

        // void user( out string name)
        // {
        //     name = "karim";
        // }

        // user(out name);
        // Console.WriteLine(name);


        //params

        // int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // int sum(params int[] num)
        // {
        //     int sum = 0;
        //     foreach (int n in num)
        //     {
        //         sum += n;
        //     }
        //     return sum;

        // }


        // // System.Console.WriteLine(sum(nums));
        // System.Console.WriteLine(sum(10, 20, 30, 40, 50, 60, 70, 80, 90, 100));


        }



        #endregion



    public static void hello()
    {
        Console.WriteLine("Hello World!");
    }

    public static string userInfo(string fName, string lName)
    {
        return $"{fName} {lName}";
    }

    public static string userInfo(string fName, string lName, int age)
    {
        return $"{fName} {lName} {age}";
    }



}
