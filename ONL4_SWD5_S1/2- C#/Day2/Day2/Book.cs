using System;
using System.Collections.Generic;
using System.Text;

namespace Day2
{
    internal class Book
    {

       public const  int maxCopies = 1; 
        //field
        private string _title;
        private string _author;
        private int _copies;
        private DateTime _createdAt;


        //props

        //auto prop
        public string Title { get { return _title; } }
        public int MyProperty { get; private set; }

        public int Copies 
        { 
            get 
            {
                return _copies;
            }
            set
            {
                if (value == maxCopies )
                {
                    _copies = value;
                }
                else
                {
                    Console.WriteLine("cannot added");
                }
                    
            }
        }

        //full prop
        //public string Title
        //{
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
        //            Console.WriteLine("invalid title");
        //        }
        //    }
        //}

        //constructors


        //default

        public Book()
        {
             _createdAt = DateTime.Now;
        }


        public Book(string title, string author)
        {
            _title = title;
            _author = author;
        }

        public Book(Book book)
        {
            _title = book.Title;
            _author = book._author;
        }


        //methods
        public void SetTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                _title = title;
            }
            else
            {
                Console.WriteLine("invalid title");
            }
        }

        public string GetTitle()
        {
            return _title; 
        }

        public void Display()
        {
            Console.WriteLine($"Title: {Title},{_author}, Copies: {Copies}, created at:{_createdAt}");
        }
}
}
