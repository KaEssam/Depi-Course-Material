using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAL_S1
{
    class LibraryItem
    {
        //private static int _isbn;
        private static string _isbn;
        protected string _title;
        private string _category;

        //public string ISBN { get { return $"ISBN{_nextId:D5}"; } }

        //validtion
        public string ISBN { get { return _isbn; } }
        public virtual string Title { get { return _title; } set {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("invalid");
                }
                else
                {
                    _title = value;

                }
            } }
        public string Category { get; set; }
        private static int _nextId = 100;

        private DateTime _createAt;


        public LibraryItem()
        {
            Console.WriteLine("Default base Constructor");
            _isbn = GenerateId();
            _createAt = DateTime.Now;
            Console.WriteLine(ISBN);
            Console.WriteLine(_createAt);
        }

        public LibraryItem(string title, string catrgory) : this()
        {
            Console.WriteLine("Paramterized base contructor");

            //if (string.IsNullOrEmpty(title))
            //{
            //    Console.WriteLine("invalid");
            //}
            //else
            //{
            //    Title = title;

            //}
            Title = title;
            Category = catrgory;
        }


        public virtual void DisplyInfo()
        {
            Console.WriteLine($"ID: {ISBN}");
            Console.WriteLine($"Title: {Title}");
        }

        private static string GenerateId()
        {
            //ISBN00100
            _nextId++;
            return  $"ISBN{_nextId:D5}";
            //return _nextId;
        }




    }
}
