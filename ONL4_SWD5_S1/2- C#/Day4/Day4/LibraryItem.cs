using System;
using System.Collections.Generic;
using System.Text;

namespace Day4
{
    internal abstract class LibraryItem
    {
        private static int itemNum = 0;

        public string Id { get; }
        public string Title  { get; set; }
        public abstract string Category { get; set; }

        public LibraryItem()
        {
            Id = GenerateId();
            Console.WriteLine("Base Class CTOR");
        }

        public LibraryItem(string title):this() 
        {
            Title = title;
        }

        // ABSTRACT METHOD = MUST IMPLMENT VIA CHILD !!!
        public abstract void CreateItem(string title);
        
        // CONCRET METHOD
        public void ItemInfo()
        {
            Console.WriteLine(Title);
        }

        private string GenerateId()
        {
            return $"ISBN{++itemNum:D5}";
        }

        //public abstract string Buy();
        //public abstract string Borrow();
    }
}
