using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S2_Day3
{
    // base class => drived class
   internal class LibraryItem
    {
        private string _id;
        protected string _title;
        private string _price;
        private string _category;
        protected DateTime _CreateAt;


        // add validtion 
        public string Id { get{ return _id; } }
        public virtual string Title { get{ return _title; } set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("invalid");
                }
                else
                {
                    _title = value;
                }
            } }
        public decimal Price { get; set; }
        public string Category { get; set; }

        private static int _itemId = 100;
        private static int _TotalItem = 0;


   

        public LibraryItem()
        {
            Console.WriteLine("default base constructor");
            _id = generateId();
            _CreateAt = DateTime.Now;
            Console.WriteLine($"id:{Id}, Create At: {_CreateAt}");
            _TotalItem++;
            Console.WriteLine($"count item: {_TotalItem}");
        }

        public LibraryItem(string title, decimal price) : this()
        {
            Console.WriteLine("base Parameterized constructor");
            Title = title;
            Price = price;
        }

        public virtual void DisplyInfo()
        {
            Console.WriteLine($"id: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Created At: {_CreateAt}");
        }

        private static string generateId()
        {
            return $"ISBN{_itemId++:D5}";
        }
    }
}
