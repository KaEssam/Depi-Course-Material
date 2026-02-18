using System;
using System.Collections.Generic;
using System.Text;

namespace Day4
{
    internal abstract  class LibraryItem
    {
        public string Title { get; set; }
        public abstract int Count { get; set; }

        public static int Copy { get; set; }
        public LibraryItem()
        {
            Console.WriteLine("base Constructor");
        }

        public virtual void ItemInfo()
        {
            Console.WriteLine(Title);
        }

        public abstract void Details();
        //public abstract void Printable(); //ebook? courses? 
        //public abstract void Readabel(); //courses?a

    }
}
