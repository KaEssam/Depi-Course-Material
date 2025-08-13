using MNF_S1_Day3;

namespace MNF_S1_Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");



            //LibraryItem libraryItem = new LibraryItem();

            //IBorrowable borrowable = new IBorrowable();

            //staticClass staticClass = new staticClass();
            //Console.WriteLine(staticClass.Id = 10);
            //Console.WriteLine(staticClass.Id = 10);
            //Console.WriteLine(staticClass.Id = 10);
            //Console.WriteLine(staticClass.Id = 10);

            //sealedClass sealedClass = new sealedClass();

            book book = new book();
            //book.id = 10;
            //book.displyInfo();

            book.Review.rate();

            

        }
    }

    class RegularClass
    {
        //=> entity 
        // field 
        // props
        // ctor
        // methods
    }

    class AbstractClass
    {
        // base class for commen classes
        // shared implmentions
        // cant make init object
        // regular members 
        // abstract members 
    }


    // upload image();

    static class staticClass
    {
        //public int id { get; set; } // error
        // members must be static

        public static int Id { get; set; }

        static staticClass()
        {
            Console.WriteLine("static ctor");
        }
    }


    sealed class sealedClass : RegularClass
    {
        public int Id { get; set; }
    }

    //partial class Book
    // {
    //     public int id { get; set; }
    // }

    //partial class Book
    // {
    //     public void displyInfo()
    //     {
    //         Console.WriteLine($"info {id}");
    //     }
    // }


    // dto =>  create(id,name), update name  

    //createempDto , updateempDto,resoposeEmpDto
    // empDto 
    // nested class => 
    class book
    {
        
        void disply()
        {
            //Review review = new Review();
            //review.rate();
        }

      public static class Review
        {
            public static void rate()
            {
                Console.WriteLine("high rate");
            }
        }
    }


    // obj relations

    // obj book , obj user 

    class book1
    {
        public  int UserId { get; set; }
        public user user { get; set; }

        public List<library> libraries { get; set; }
    }

    class user
    {

    }

    class library
    {
        public List<book1> books { get; set; }

    }

    // self study(struct,destructor, disposalble, operator overload)

    //


}
