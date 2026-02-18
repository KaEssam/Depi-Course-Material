using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    internal class Book : LibraryItem
    {
        //fileds 

        //private string _title;
        //private DateTime _createdAt;

        //prop
        //public string Title
        //{
        //    get { return _title; }
        //    set
        //    {
        //        if (!string.IsNullOrEmpty(value))
        //        {
        //            _title = value;
        //        }
        //    }
        //}

        //public string Title { get; }




        //

        public string Author { get; set; }
        public int Copies { get; set; }


        public Book(string Title):base(Title)
        {
            Console.WriteLine("Book CTOR");
        }


        public override void Info()
        {
            Console.WriteLine($"Book Info.. Book Id: {Id}, Book Title: {Title}, Author: {Author}, Description: {Description}, Category: {Category}");
        }

        public void test(string test)
        {
            _name = test;
        }





    }
}
