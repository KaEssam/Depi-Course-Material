using MNF_S1_Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S1_Day3
{
    class Book : LibraryItem, IBorrowable,IRenewable
    {
        //public string Title { get; set; }
        //public int BookId { get; set; }
        //public decimal Price    { get; set; }
        //public string Category { get; set; }

        public string Author { get; set; }

        public override string Title {
            get { return _title; }
            set
            {
                if (string.IsNullOrEmpty(value)){
                    Console.WriteLine("invalidd book title");
                }
                else
                {
                    _title = value;
                }
            }
        }

        public override string ItemType => throw new NotImplementedException();

        public bool IsAvailable => throw new NotImplementedException();

        public Book()
        {
            Console.WriteLine("book constructo");
        }
        public Book(string title, string author) :base(title)
        {
            Console.WriteLine("Paramterized Book contructor ");
            Author = author;

            
        }

        //public Book():this():base()
        //{
            
        //}

        // method hiding
        //public new void displayINfo()
        //{
        //    Console.WriteLine($"Title: {Title}");
        //    Console.WriteLine($"Id: {_itemId}");
        //    Console.WriteLine($"Added in: {DateAdd}");
        //    Console.WriteLine($"Author: {Author}");
        //}

        //public new void displayINfo()
        //{
        //    Console.WriteLine($"Title: {Title}");
        //    Console.WriteLine($"Id: {_itemId}");
        //    Console.WriteLine($"Added in: {DateAdd}");
        //    Console.WriteLine($"Author: {Author}");
        //}

        public sealed override string ToString()
        {
            return $"Book:{Title} by {Author}";
        }

        public override void hello()
        {
            Console.WriteLine("hello from book class");
        }

        public override void displayINfo()
        {
            throw new NotImplementedException();
        }

        public override bool Borrow(string ItemName)
        {
            throw new NotImplementedException();
        }

        public bool Renew()
        {
            throw new NotImplementedException();
        }

        public bool Return()
        {
            throw new NotImplementedException();
        }


        //bool isAvailable = true;
        //public bool Borrow(string BookName)
        //{
        //    if (!isAvailable)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        isAvailable = false;
        //        return true;
        //    }

        //}

    }
}
