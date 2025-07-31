using System.Collections;

namespace MNF_S2_Day2;

class Program
{
    static void Main(string[] args)
    {
        #region value type & reference type

        // int x = 5;
        // int y = x;
        //
        // Console.WriteLine(y);
        // y = 20;
        // x = 30;
        // Console.WriteLine(x);
        // Console.WriteLine(y);
        //
        //
        // int[] nums = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        // int[] n = nums;
        //
        // Console.WriteLine(nums[0]); //1
        // Console.WriteLine(n[0]); //1
        //
        // n[0] = 50;
        // Console.WriteLine(nums[0]); //50
        // Console.WriteLine(n[0]); //50

        #endregion

        #region Boxing & unboxing

        // int x = 20;
        //
        // object obj = x; //boxing
        //
        // int x1 = (int)obj; //unboxing
        //



        #endregion

        #region Type Casting

        // implicit casting => smaller to bigger data type 
        //
        // int x = 5;
        //
        // double y = x; //5.0

        // explicit casting 

        // double x = 5.5;
        //
        // int y = (int)x; //5

        // Convert (all datatypes)

        // int str = 123;
        // string num = Convert.ToString(str);
        // Console.WriteLine(num);


        //Parse (numeric)

        // string str = "123";
        // double num = double.Parse(str);
        // Console.WriteLine(num);


        //string str = "abc";
        //int num = int.Parse(str);
        //Console.WriteLine(num);

        //ali essam -5 
        // TryParse => self study (bouns)

        //string str = "abc";
        //if (int.TryParse(str, out int number))
        //{
        //    Console.WriteLine(number + "convert success");
        //}
        //else
        //{
        //    Console.WriteLine("enter valild num");
        //}


        #endregion

        #region Operatores

        //#####################
        // Math
        //#####################

        // int a = 10, b = 3;
        //
        // Console.WriteLine(a + b);  // 13
        // Console.WriteLine(a - b);  // 7
        // Console.WriteLine(a * b);  // 30
        // Console.WriteLine(a / b);  // 3
        // Console.WriteLine(a % b);  // 1

        //#######################
        // increment & decrement
        //########################

        // int x = 10;
        // Console.WriteLine(x);//10
        // Console.WriteLine(++x); //11 => 1 + x
        // Console.WriteLine(x); //11
        // Console.WriteLine(x++); //11 x + 1
        // Console.WriteLine(x); // 12
        //
        //
        // Console.WriteLine(--x); //11
        // Console.WriteLine(x); //11
        // Console.WriteLine(x--); //11
        // Console.WriteLine(x); //10

        //##################
        // Assigment
        //##################

        // int x = 10;
        // Console.WriteLine(x+=4); //14
        // Console.WriteLine(x*=9); //126
        // Console.WriteLine(x-=5); // 121
        // Console.WriteLine(x/=3); // 40
        // Console.WriteLine(x%=10); //0

        //#################
        // Comparison
        //#################

        // int num = 10;
        //
        // bool isLessThan = num < 10;
        // bool isGreaterThan = num > 10;
        // bool isEqualTo = num == 10;
        // bool isNotEqualTo = num != 10;
        // bool isLessThanOrEqualTo = num <= 10;
        // bool isGreaterThanOrEqualTo = num >= 10;
        //
        // Console.WriteLine(isLessThan); //false
        // Console.WriteLine(isGreaterThan);//false
        // Console.WriteLine(isEqualTo); // true
        // Console.WriteLine(isNotEqualTo); //false
        // Console.WriteLine(isLessThanOrEqualTo); //true
        // Console.WriteLine(isGreaterThanOrEqualTo); //true

        //#################
        // Logical
        //################

        // bool isTrue = true;
        // bool isFalse = false;
        // bool result;
        //
        // // && => true if both true
        // result = isTrue & !isFalse;
        // Console.WriteLine(result);
        //
        // // || => if anyone true = true
        //
        // result = isTrue || isFalse;
        // Console.WriteLine(result); //true

        // ^ 

        // result = isTrue ^ isFalse;
        // Console.WriteLine(result); // true
        //
        // result = isTrue ^ isTrue;
        // Console.WriteLine(result); //false
        #endregion

        #region  if .. else

        // if (false)
        // {
        //     Console.WriteLine("true");
        // }
        // else
        // {
        //     Console.WriteLine("false");
        // }

        // Console.Write("Enter Number: ");
        // int number = Convert.ToInt32(Console.ReadLine());

        // if (number == 0)
        // {
        //     Console.WriteLine("number is zero");
        // }
        // else if (number % 2 == 0)
        // {
        //     Console.WriteLine($"{number} is even");
        // }
        // else
        // {
        //     Console.WriteLine($"{number} is odd");
        // }


        // if (number % 2 == 0)
        // {
        //     if (number == 0)
        //     {
        //         Console.WriteLine("number is zero");
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

        // if (number % 2 == 0 && number != 0)
        // {
        //     Console.WriteLine($"{number} is even");
        // }
        // else if (number == 0)
        // {
        //     Console.WriteLine("number is zero");
        // }
        // else
        // {
        //     Console.WriteLine($"{number} is odd");
        // }


        #endregion

        #region ternery op

        // // condition? true part: false part
        //
        // Console.Write("Enter Number: ");
        // int number = Convert.ToInt32(Console.ReadLine());
        //
        // // string result = number % 2 == 0 ? "even" : "odd";
        //
        // string result = number % 2 == 0 && number != 0 ? "even" : number == 0 ? "number is zero" :"odd";
        //
        // Console.WriteLine(result);

        #endregion

        #region switch

        // int day = 1;
        //
        // if(day == 1)
        //     Console.WriteLine("sat");
        // else if(day == 2)
        //     Console.WriteLine("sun");
        // else if(day == 3)
        //     Console.WriteLine("tue");
        // else
        //     Console.WriteLine("Weekend");
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

        #region loops

        //for => for(initial, condition, increment/decrement)

        // for (int i = 0; i <= 10; i++)
        // {
        //     Console.WriteLine(i);
        // }

        // foreach => foreach(type variable in array)

        // int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        //
        // foreach (double number in numbers)
        // {
        //     Console.WriteLine(number);
        // }

        // while 



        // do.. while

        // int x = 10;
        // do
        // {
        //     Console.WriteLine(x);
        //     x++;
        // } while (x > 30);


        // break

        // for (int i = 0; i <= 10; i++)
        // {   
        //     if(i ==5)
        //         break;
        //     Console.WriteLine(i);
        // }


        // for (int i = 0; i <= 10; i++)
        // {   
        //     if(i ==5)
        //         continue;
        //     Console.WriteLine(i);
        // }
        #endregion

        #region Array

        // int[] numbers = new int[5];
        //
        // numbers[0] = 1;
        // numbers[1] = 2;
        // numbers[2] = 3;
        // numbers[3] = 4;
        // numbers[4] = 5;
        // // numbers[5] = 6;
        //
        //
        // Console.WriteLine(numbers[0]);
        // Console.WriteLine(numbers[numbers.Length-1]);
        // Console.WriteLine(numbers[^(numbers.Length)]);

        // Console.WriteLine(numbers[0]);
        //
        // int[] copy = new int[10];
        // Array.Copy(numbers,copy,4);
        // Console.WriteLine(copy[3]); // 4
        //
        // Array.Resize(ref numbers,20);
        // Console.WriteLine(numbers[15]);

        //
        // int[] nums = new int[5]{1,2,3,4,5};
        // int[] n = { 1, 2 };
        // char[,] letters = new char[3, 2]
        // {
        //     {'A','B'},
        //     {'C','D'},
        //     {'E','F'},
        // };
        //
        // letters[0, 0] = 'A';

        // int[][] arr = new int[2][];
        // arr[0] = new int[2] {1,3};
        // arr[1] = new int[5]{1,2,3,4,5};


        #endregion

        #region methods

        // access modifier static return type(void) name(params){code block}

        //Hello();

        // Console.WriteLine(userInfo("karim", "essam"));
        //
        // Console.WriteLine(userInfo("ali","essam",20));

        #endregion


        #region Passing By Value & Passing By Referance

        // Passing by Value => copy data 

        //int x = 5; //data

        //int addFive(int num)
        //{
        //  return  num += 5;
        //}

        //Console.WriteLine(addFive(x)); //10 => x = 10
        //Console.WriteLine(x); // 10

        ////////// 2000 + 1000
        ///ref

        //int z = 5; // z=10

        //int addFive(ref int num)
        //{
        //    return num += 5;
        //}

        //Console.WriteLine(addFive(ref z)); //10 => x = 10
        //Console.WriteLine(z); // 10

        //// out

        //void userInfo(out string fname, out string lname)
        //{
        //    //data from database
        //    fname = "ahmed";
        //    lname = "ali";
        //}

        //string FirstName = "ahmed";
        //string LastName = "ali";
        //userInfo(out FirstName,out LastName);
        //Console.WriteLine($" your first name {FirstName} dsdasdafda {LastName}");


        //Params

        //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //int sum(params int[] nums)
        //{
        //    int total = 0;

        //    for(int i =0; i < nums.Length; i++)
        //    {
        //        total += nums[i];

        //    }
        //    //foreach (int n in nums)
        //    //{
        //    //    total += n;
        //    //}
        //    return total;
        //}

        //Console.WriteLine(sum(nums));
        //Console.WriteLine(sum(10,20,30,40,50));


        #endregion


    }

    public static void Hello()
    {
        Console.WriteLine("Hello World!");
    }

    public static string userInfo(string fname, string lname)
    {
        return $"{fname} {lname}";
    }
    
    public static string userInfo(string fname, string lname,int age)
    {
        return $"{fname} {lname}, {age}";
    }
}