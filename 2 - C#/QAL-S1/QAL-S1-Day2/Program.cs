using System.Collections;

namespace QAL_S1_Day2;

class Program
{
    static void Main(string[] args)
    {
        #region Value Type & Reference Type
        //
        // int a = 10;
        // int b = a;
        //
        // Console.WriteLine(a);//10
        // Console.WriteLine(b);//10
        // Console.WriteLine("-------------");
        //
        // a = 20;
        // Console.WriteLine(a); //20
        // Console.WriteLine(b); //10
        //
        // int [] x = {1,2,3,4,5};
        // int[] y = x;
        //
        // Console.WriteLine(y[1]);//2
        //
        // y[1] = 20;
        // Console.WriteLine(x[1]); //20

        #endregion

        #region Boxing & Unboxing

        // int x = 20; // value type
        //
        // object obj = x; // reference
        //
        // int y = (int)obj; //unboxing
        
        

        #endregion

        #region Type Casting
        
        //implicit casting => from small datatype to bigger 
        // int x = 20;
        // double y = x;
        
        //Explicit casting
        // double x = 20.50;
        // int y = (int)x; 
        
        // //Convert (ALL DATA TYPES) => STRING TO NUMS 
        //
        // string str = "123";
        // string str2 = "ABC"; // ERROR
        // int num = Convert.ToInt32(str);
        // Console.WriteLine(num);
        //
        // // PARSE (NUMERIC ONLY) 
        //
        // String STR = "123";
        // int num2 = int.Parse(STR);
        //
        // Console.WriteLine(num2);
        
        // TRY PARSE (Bouns) 
        #endregion

        #region Operatores

        // ################
        // Math => + * / - %
        //#################
        
        // int a = 10, b = 3;
        //
        // Console.WriteLine(a + b);  // 13
        // Console.WriteLine(a - b);  // 7
        // Console.WriteLine(a * b);  // 30
        // Console.WriteLine(a / b);  // 3
        // Console.WriteLine(a % b);  // 1
        
        
        // ################
        // increment  Decrement
        //#################

        // int x = 10;
        //
        // Console.WriteLine(x); //10
        // Console.WriteLine(++x); //11 1+10
        // Console.WriteLine(x); //11
        // Console.WriteLine(x++); //11 11 +1
        // Console.WriteLine(x); //12
        //
        // Console.WriteLine("----------------");
        // Console.WriteLine(--x); // 11
        // Console.WriteLine(x); // 11
        // Console.WriteLine(x--); //11
        // Console.WriteLine(x); //10
        
        // ################
        // Comparison = > < >= != ==
        //#################

        // int num = 10;
        //
        // bool isLessThan = num < 10; // false
        // bool isGreaterThan = num > 10; // false
        // bool isEqualTo = num == 10; // true
        // bool isNotEqualTo = num != 10; // false
        // bool isGreaterThanOrEqualTo = num >= 10; // true
        // bool isLessThanOrEqualTo = num <= 10; // true
        //
        // Console.WriteLine(isLessThan);
        // Console.WriteLine(isGreaterThan);
        // Console.WriteLine(isEqualTo);
        // Console.WriteLine(isNotEqualTo);
        // Console.WriteLine(isGreaterThanOrEqualTo);
        // Console.WriteLine(isLessThanOrEqualTo);
        
        
        // ################
        // Logical && || 
        //#################

        // bool isTrue = true;
        // bool isFalse = false;
        // bool result;
        //
        // // && => true if both true
        // result = isTrue && isFalse; // 
        // Console.WriteLine(result);
        //
        // // || => true if one true
        //
        // result = isTrue || isFalse;
        // Console.WriteLine(result);
        //
        // // ^ (XOR) => false if both are same
        //
        // result = isTrue ^ isFalse;
        // Console.WriteLine(result);
        //
        // result = isTrue ^ isTrue;
        // Console.WriteLine(result);
        //
        // result = isFalse ^ isFalse;
        // Console.WriteLine(result);
        

        // int score = 10;
        // score += 5;  // score = score + 5 => 15
        // score -= 3;  // score = score - 3 => 12
        // score *= 2;  // score = score * 2 => 24
        // score /= 4;  // score = score / 4 => 6


        #endregion

        #region if .. else


        // if (false)
        // {
        //     Console.WriteLine("true");
        // }
        // else
        // {
        //     Console.WriteLine("false");
        // }

        // // 0 number is zero
        // Console.Write("Enter a number: ");
        //
        // int number = Convert.ToInt32(Console.ReadLine());
        // //
        // // if (number % 2 == 0 && number != 0)
        // // {
        // //     Console.WriteLine($"{number} is even");
        // // }
        // // else if (number == 0)
        // // {
        // //     Console.WriteLine("number is zero");
        // // }
        // // else
        // // {
        // //     Console.WriteLine($"{number} is odd");
        // // 
        //
        // if (number == 0)
        //     Console.WriteLine("number is zero");
        // else if (number % 2  == 0)
        //     Console.WriteLine($"{number} is even");
        // else
        //     Console.WriteLine($"{number} is odd");
        

        #endregion

        #region ternery op
        //  //short cut for if else 
        // //syntax => condition is true ? true result : false result
        //
        // Console.Write("Enter a number: ");
        //
        // int number = Convert.ToInt32(Console.ReadLine());
        //
        // string result =  number % 2 == 0 && number !=0 ? $"{number} is even" : "odd";
        // Console.WriteLine(result);
        
        
        #endregion

        #region  Switch

        // int day = 6;
        //
        // if(day == 1) //false
        //     Console.WriteLine("sat");
        // else if(day == 2) //false
        //     Console.WriteLine("sun");
        // else if(day == 3) //false
        //     Console.WriteLine("moon");
        // else if(day == 4) 
        //     Console.WriteLine("thu");
        // else if(day == 5)
        //     Console.WriteLine("fri");
        // else
        //     Console.WriteLine("weekend");
        //
        // switch (day) // 6
        // {
        //     case 1:
        //     case 6:
        //         Console.WriteLine("sat");
        //         break;
        //     case 2:
        //         Console.WriteLine("sun");
        //         break;
        //     case 3:
        //         Console.WriteLine("moon");
        //         break;
        //     case 4:
        //         Console.WriteLine("thu");
        //         break;
        //     case 5:
        //         Console.WriteLine("fri");
        //         break;
        //     default:
        //         Console.WriteLine("weekend");
        //         break;
        // }

        #endregion

        #region loops

        // for loop => for(intial; condition; icrement/decrement)

        // for (int i = 0; i <= 10 ; i++)
        // {
        //     Console.WriteLine(i);
        // }
        
        // foreach => foreach(type variable in array)
        
        // int[] nums = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        //
        //
        // foreach (double num in nums)
        // {
        //     Console.WriteLine(num);
        // }
        
        // while => while (condition) {code block}

        // int x = 20;
        //
        // while (x < 30 && x > 0)
        // {
        //     Console.WriteLine(x);
        //     x--;
        // }
        
        
        // do .. while 

        // int y = 20;
        //
        // do
        // {
        //     Console.WriteLine(y);
        //     y--;
        // } while (y < 30);
        
        
        // // break
        //
        // for (int i = 0; i <= 10 ; i++)
        // {
        //     if(i == 5)
        //         break;
        //     Console.WriteLine(i);
        // }
        //
        // //continue
        // for (int i = 0; i <= 10 ; i++)
        // {
        //     if(i == 5)
        //         continue;
        //     Console.WriteLine(i);
        // }

        #endregion

        #region array

        // int[] x = new int[4]{1,2,3,4};
        
        // int[] nums = new int[5];
        // Console.WriteLine(nums[0]);
        // nums[0] = 1;
        // nums[1] = 2;
        // nums[2] = 3;
        // nums[3] = 4;
        // nums[4] = 5;
        //
        // // Console.WriteLine(nums[0]);
        // // Console.WriteLine(nums[1]);
        // // Console.WriteLine(nums[2]);
        // // Console.WriteLine(nums[3]);
        // // Console.WriteLine(nums[4]);
        // // Console.WriteLine(nums[5]);
        // // Console.WriteLine(nums[6]);
        //
        // // Console.WriteLine(nums.Length); //5
        //
        // // Console.WriteLine(nums[0]);
        // // // Console.WriteLine(nums[nums.Length-1]);
        // //
        // // // seif
        // // Console.WriteLine(nums[^1]);
        // // Console.WriteLine(nums[^nums.Length]);
        // // Console.WriteLine(nums[^(nums.Length-1)]);
        //
        // //
        // // Array.Reverse(nums);
        // // Console.WriteLine(nums[0]);
        // //
        // // int[] copy = new int[20];
        // // Array.Copy(nums, copy, 4);
        // //
        // // Console.WriteLine(copy[18]);
        //
        // Console.WriteLine(Array.Exists(nums, x => x == 3));
        //
        //
        // char[,] letters = new char[5, 5]
        // {
        //     {'a','b','c','d','e'},
        //     {'e','f','g','h','c'},
        //     {'i','j','k','l','d'},
        //     {'l','m','n','o','p'},
        //     {'o','p','q','r','s'},
        // };
        //
        // Console.WriteLine(letters[0, 3]);

        #endregion

        #region Methods

        // // access modifier -stactic - return datatype (void) - name (parms)
        //
        // hello();
        //
        // Console.WriteLine(info("karim", "Essam"));


        #endregion
        
        // bank project ()
    }

    // static void hello()
    // {
    //     Console.WriteLine("Hello World!");
    // }
    //
    // static string info(string firstName, string lastName)
    // {
    //     return $"{firstName} {lastName}";
    // }
    //
    // static string info(string firstName, string lastName,int age)
    // {
    //     return $"{firstName} {lastName}";
    // }
}