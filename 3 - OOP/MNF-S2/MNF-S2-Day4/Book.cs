using MNF_S2_Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S2_Day3
{
    class Book : IBorrowable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public static int Copies { get; set; } = 5;
        public static bool IsPopular { get; set; }
        public bool isAvaliable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        //public Book()
        //{

        //}

        //public Book(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}

        //public Book(int id, string name) : this(id, name, 1)
        //{
        //    Id = id;
        //    Name = name;
        //    Price = 1;
        //}


        //public Book(int id, string name, decimal price, bool isPopular) : this(id, name)
        //{
        //    Price = price;
        //    //IsPopular = isPopular;
        //    //IsPopular = isPopular;
        //}

        //public Book(int id, string name, decimal price) : this(id, name, price, IsPopular? true : false)
        //{
        //    Console.WriteLine($"POPULAR{IsPopular}");
        //    Price = price;
        //}

        public Book(int id, string name, decimal price, int copies, bool isPopular)
        {
            Id = id;
            Name = name;
            Price = price;
            Copies = copies;
            IsPopular = isPopular;
        }

        public Book(int id, string name, decimal price, int copies)
            : this(id, name, price, copies, copies > 5 ? true : false)
        {
        }

        public bool Borrow(string itemName)
        {
            throw new NotImplementedException();
        }

        public bool Return()
        {
            throw new NotImplementedException();
        }

        
    }
}
