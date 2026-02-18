using System;
using System.Collections.Generic;
using System.Text;

namespace Day4
{
    internal class Book : LibraryItem,IReadable
    {
        int Test { get; set; }
        public override int Count { get; set; }
        //public int Test { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public sealed override void Details()
        {
            Console.WriteLine($"Book {Title}");
        }

        public void Readable()
        {
            throw new NotImplementedException();
        }
    }
}
