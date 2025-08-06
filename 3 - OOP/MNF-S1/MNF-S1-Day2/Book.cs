using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S1_Day2
{
    class Book
    {
        //ctrl + shift + a

        //field => data storage

        //public string Tilte;
        private string _tilte;

        //public void setTitle(string title)
        //{
        //    // VALIDATION
        //    if(string.IsNullOrWhiteSpace(title) || string.IsNullOrEmpty(title))
        //    {
        //        Console.WriteLine("invalid title");

        //    }
        //    else
        //    {
        //        _tilte = title;
        //    }

        //}

        //public string getTitle()
        //{
        //    return _tilte;
        //}

        // auto implment property

        //public string Title { 
        //    get
        //    {
        //        return _tilte;
        //    } set
        //    {
        //        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
        //        {
        //            Console.WriteLine("invalid title");

        //        }
        //        else
        //        {
        //            _tilte = value;
        //        }

        //    }
        //}


        ////////
        /// const, readonly, private set, static readonly 
        ////
        ///

        //public const int Max_Copies = 200;

        //private int _copies;
        //public int Copies { get { return _copies; } set 
        //    {
        //        if (value > Max_Copies)
        //        {
        //            Console.WriteLine("ERROR");
        //        }
        //        else
        //        {
        //            _copies = value;
        //        }

        //    }
        //}

        //public DateTime UpdateAt { get; }

        //public readonly DateTime CreateAt = DateTime.Now;

        //public string Branch { get;} = "Cairo";

        //public Book()
        //{
        //    CreateAt = DateTime.Now;
        //    UpdateAt = DateTime.Now;
        //    Console.WriteLine(CreateAt);
        //    Console.WriteLine(UpdateAt);
        //    Console.WriteLine(Branch);
        //}

        //public int ISBN { get; private set; }

        //public void setISBN(int isbn)
        //{
        //    ISBN = isbn;
        //}

        /// static readonly
        /// 

        //public static const int isbn = 100;

        //public DateTime PublishYear { get; set; }

        // computed prop
        //public int BookAge
        //{
        //    get
        //    {
        //        return DateTime.Now.Year - PublishYear.Year;
        //    }
        //}

        //public string BookDescription
        //{
        //    get
        //    {
        //        return $"{BookAge} years old";
        //    }
        //}

        //public int test1 { get; set; }

        //private int _test2;

        //public int Test2 { get { return _test2; } set { // validtion
        //                                                _test2 = value; } }

        //public readonly int Test3;
        //public int Test4 { get;}

        //public Book(int test3, int test4)
        //{
        //    Test3 = test3;
        //    Test4 = test4;
        //}


        public int ISBN { get; set; }
        public string Title { get; set; } = "Unkonw Title";
        public string Author { get; set; } = "Unkonw Author";
        public int Copies { get; set; } = 0;
        public string Branch { get; } = "Cairo";

        public int BookId { get; private set; }

        private static int _nextBook =1;

        //// Constructor

        //// Default Constructor => new Book()

        public Book()
        {
            BookId = _nextBook++;
            Console.WriteLine("Default Contructor");
            Title = "Unkonw Author";
            Console.WriteLine(BookId);
        }

        //// Paramtrized Constructor => new Book("c#","omar",123456,50)




        public Book(string title, string author, int isbn)
        {
            Console.WriteLine("Paramtrized Constructor");
            Title = title;
            Author = author;
            ISBN = isbn;
            Console.WriteLine($"{Title},{Author},{ISBN}");

        }

        ////Chain Constructor

        ////=> quick constructor, extend constructor, full constructor, conditional constructor,private costructor (self study)
        //public Book(string title, string author, int isbn, int copies):this(title, author,isbn)
        //{
        //    Console.WriteLine("Paramtrized Constructor");
        //    Copies = copies;
        //    Console.WriteLine($"{Title},{Author},{ISBN},{Copies}");

        //}

        //public Book(string title, string author, int isbn, int copies, string branch):this(title,author,isbn,copies)
        //{
        //    Console.WriteLine("Paramtrized Constructor");
        //    Branch = branch;
        //    Console.WriteLine($"{Title},{Author},{ISBN}");

        //}



        ////Copy Constructor
        public Book(Book book)
        {
            Console.WriteLine("Copy Constructor");
            Title = book.Title;
            Author = book.Author;
            ISBN = book.ISBN;
            Copies = book.Copies;
            Console.WriteLine($"{Title},{Author},{ISBN},{Copies}");
        }



        // helper method
        //private static int generateBookId()
        //{
        //    return _nextBook++;
        //}


        ///////////////////////////
        /// Static Constructor , static readonly
        ///

        public static readonly string Name;
        static Book()
        {
            Name = "cairo";
            Console.WriteLine("static constructor");
            Console.WriteLine(Name);
        }




    }
}
