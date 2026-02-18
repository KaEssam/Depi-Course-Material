using System;
using System.Collections.Generic;
using System.Text;

namespace Day4
{
    internal  class Book : LibraryItem
    {
        //filed 
        private string _title;

        public override string Category { get; set; } = "Book";
        public string type { get; set; }

        //public override string Borrow()
        //{
        //    throw new NotImplementedException();
        //}

        //public override string Buy()
        //{
        //    throw new NotImplementedException();
        //}

        public sealed override void CreateItem(string title)
        {
            Title = title;
        }

        public void Read()
        {
            Console.WriteLine("Book Read");
        }

        public void test()
        {
            Console.WriteLine("Test");
        }

        public void Write()
        {
            Console.WriteLine("can write in the book");
        }
    }
}
