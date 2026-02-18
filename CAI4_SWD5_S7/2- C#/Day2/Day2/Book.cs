using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Day2
{
    internal class Book
    {

        // field
        // props
        // constructors
        //methods

        private string _title; //c#

        
        public int Copies { get; init; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        //public string Title 
        //{   
        //    get 
        //    {
        //        return _title;
        //    }
        //    set
        //    {
        //        if(!string.IsNullOrWhiteSpace(value))
        //        {
        //            _title = value;
        //        }
        //        else
        //        {
        //            Console.WriteLine("invalid title");
        //        }
        //    }
        //}



        //public Book()
        //{
        //    Title = "Test";
        //    Copies = 1;
        //}

        public Book(string title)
        {
            Title = title;
        }


        public Book(string title, string author, int copies, int isbn)
        {
            Title=title;
            Author = author;
            ISBN = isbn;
            Copies = copies;
        }


        public Book(Book Copybook)
        {
            Title= Copybook.Title;
        }
        public void Borrow()
        {
            if(Copies == 0)
            {
                Console.WriteLine("book not exist");
            }
            else
            {
                Console.WriteLine("Borrowed");
            }
        }
        public void Display()
        {
            Console.WriteLine($"Title: {_title}");
        }
        //public void SetTitle(string title)
        //{

        //    _title = title; 
        //}

        //public string GetTitle()
        //{
        //    return _title;
        //}
    }
}
