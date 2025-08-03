using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAL_S1_Day2
{
    class Book //=> contain all data for the book 
    {
        // title, author, isbn, copies

        //memebers => field, properties, method, conctructor


        // field => data storage 
        //private string _title;

        //public string title; //direct access to data 

        //public void setTitle(string Title)
        // {
        //     //validation => rules 
        //     _title = Title;
        // }

        //public string getTitle()
        // {
        //     return _title;
        // }


        // auto implemnt prop => CREATE PRIVETE FIELD

        //public string  Title { get; set; }
        //public int ISBN
        //{
        //    get
        //    {
        //        return ISBN;
        //    }
        //    set
        //    {
        //        // VALIDTION
        //        ISBN = ISBN;
        //    }
        //}

        //public Book(int isbn,string branch)
        //{
        //   this.isbn = isbn;
        //    Branch = branch;

        //}

        // read only , privte set, constent, static read only


        // READ ONLY PROP, SET USING CONSTRUCTOR , set once per instecne 
        //public int ISBN { get; }



        // private set

        //public int ISBN { get; private set; }

        //// method helper for set ISBN

        //public void setISBN(int isbn)
        //{
        //    // validation 
        //    ISBN = isbn;
        //}


        // Constants => shared in all instacne

        //public const int Max_Borrowed =3;
        //public readonly int isbn;

        //public void info()
        //{
        //    Console.WriteLine(Max_Borrowed);
        //} 


        // const (compile-time) , read only (run time)

        // static read only => set using static constructor // later

        //public static readonly string Branch = "Main Branch";


        // Constructor

        public Book()
        {
            Console.WriteLine("default contsructor called");
        }

        // paramtrized contructor


        public string Title { get; set; }
        public int ISBN { get; }
        public string Author { get; set; }

        //public string Branch { get; }
        //public Book(string title, int isbn)
        //{
        //    Console.WriteLine("Paramatrized contructor called");
        //    Title = title;
        //    ISBN = isbn;
        //    Branch = "Cairo Branch";
        //    Console.WriteLine(value: $"{Title},{ISBN},{Branch}");
        //}


        //public Book(string title, int isbn, string author)
        //{
        //    Console.WriteLine("Paramatrized contructor called");
        //    Title = title;
        //    ISBN = isbn;
        //    Branch = "Main Branch";
        //    Console.WriteLine(value: $"{Title},{ISBN},{Branch}");
        //}


        /// CHAIN contstructor => extend contructor, full constructor. conditional consturctor
        //public Book(string title, int isbn,string author):this(title,isbn)
        //{
        //    Console.WriteLine("Chain contructor called");
        //    Author = author;
        //    Console.WriteLine(value: $"{Title},{ISBN}");
        //}

        // copy => create new obj from existing one
        //public Book(Book orginalBook)
        //{
        //    Console.WriteLine("Copy constructor");

        //    Title = orginalBook.Title;
        //    ISBN = orginalBook.ISBN;
        //    Console.WriteLine(value: $"{Title},{ISBN}");
        //}

        // static constructor

        private static readonly string Branch;
        public int test { get;}

        static Book()
        {
            Branch = "Cairo"; 
            Console.WriteLine("Static Constructor");
            Console.WriteLine(Branch);
        }

    }





    
}
