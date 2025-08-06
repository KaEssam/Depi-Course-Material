using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S2_Day2
{
    class Book
    {
        // fields , Properties

        //public string Title;

        //private string _title; // private field

        //public string getTitle()
        //{
        //    return _title;
        //}

        //public void setTitle(string title)
        //{
        //    // validtion

        //    if (!string.IsNullOrWhiteSpace(title))
        //    {
        //        _title = title;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid title");

        //    }
        //}

        //public int MyProperty { get; set; }
        //private string _title; // field => data storage 

        //// properties =>access controll 
        //public string Title { 
        //    get
        //    { 
        //        return _title;
        //    } 
        //    set
        //    {
        //        if (!string.IsNullOrWhiteSpace(value))
        //        {
        //            _title = value;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid title");

        //        }
        //    }
        //}

        // const, readonly, static readonly, private set 

        //public const int Max_copies = 200; // bussines rule

        //private int _copies;

        //public int Copies { get { return _copies; }
        //    set 
        //    {
        //        if (value < 100) 
        //            _copies = value;
        //    }
        //}

        // readonly field 
        //public string Branch { get;} // property readonly

        //public readonly string Name; // read only field

        //public Book(string branch, string name)
        //{
        //    Console.WriteLine($"{branch},{name}");
        //}


        //private set



        //public string Autor { get; private set; }

        //public void setAutor(string autor)
        //{
        //    Autor = autor;
        //}

        //public int Year { get; init; }

        // public int BorrowBooks { get; private set; }

        //public void borrowBook()
        // {
        //     BorrowBooks++; 
        // }

        // computed 

        //public DateTime PublishYear { get; set; }
        //public int BookAge { get
        //    {
        //        return DateTime.Now.Year - PublishYear.Year;
        //    }
        //}

        ////////////////////////////////
        /// Constructer
        /// 


        public string Title { get; set; }
        public string Auther { get; set; }
        public int ISBN { get; set; }
        public int Copies { get; set; }
        // Default Constructor

        public static int BookId;

        public Book()
        {
            BookId = generatebookid();
            Console.WriteLine(BookId);
            Console.WriteLine("Default Constructor");
        }


        // Parametrized contstructor

        public Book(string title, string auther, int copies)
        {

            Title = title;
            Auther = auther;
            Copies = copies;
            Console.WriteLine("paramtrized constructor");
        }


        //chain constructor
        public Book(string title, string auther, int copies, int isbn) :this(title,auther,copies)
        {
            ISBN = isbn;
            Console.WriteLine("paramtrized constructor");
        }

        public Book(string title, string auther, int copies, int isbn, string branch) : this()
        {
            ISBN = isbn;
            branch = "cairo";
            Console.WriteLine("paramtrized constructor");
        }

        public Book(Book book)
        {
            Title = book.Title;
            Auther = book.Auther;
            Copies = book.Copies;
            Console.WriteLine("copy constructor");
            Console.WriteLine($"{Title},{Auther},{Copies}");

        }

        /// chain constructor this


        // extend constructor, quick constructor, full contructor, conditonal constructor, private constructor









        // helper method 
        private static int generatebookid()
        {
            return ++BookId; 
        }





    }
}
