using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S1_Day3
{
   abstract class LibraryItem
    {

        //List<Book> books { get; set; }
        protected string _title;
        protected string _itemId;
        private static int _totalItemsCount = 0;
        private static int _nextId = 100;
        public virtual string Title { get { return _title; } set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("invalid");
                }
                else
                {
                    _title = value;
                }
            }
        }
        public string ItemId { get{ return _itemId; }}
        public DateTime DateAdd { get; }

        public abstract string ItemType { get; }

        public LibraryItem()
        {
            Console.WriteLine("Default Base contructor ");
            _itemId = GenerateItemId();
            DateAdd = DateTime.Now;
            _totalItemsCount++;

            Console.WriteLine($"item id:{_itemId}");
        }

        public LibraryItem(string title): this()
        {

            Console.WriteLine("Paramterized Base contructor ");


            Title = title;
        }


        //public virtual void displayINfo()
        // {
        //     Console.WriteLine($"Title: {Title}");
        //     Console.WriteLine($"Id: {_itemId}");
        //     Console.WriteLine($"Added in: {DateAdd}");
        // }


        public abstract void displayINfo();

        // rule 
        public abstract void hello();
        public abstract bool Borrow(string ItemName);
        
        private static string GenerateItemId()
        {
            return $"ISBN{_nextId++:D5}";
        }

    }
}
