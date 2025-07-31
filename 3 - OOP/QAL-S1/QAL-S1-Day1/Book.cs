using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAL_S1_Day1
{
    class Book
    {

        // field => data storage
        private string _title;
        private string _author;
        private int _isbn;
        private int _copies;

        //public Book(string Title, int ISBn)
        //{
        //    _title = Title;
        //    if(ISBn.ToString().Length == 10)
        //    {
        //        ISBN = ISBn;
        //    }
        //}


        // properties => data access
        public string Title {
            get
            {
                return _title;
            }
            set
            {
                // null value, empty string, white space
                //if (value == null || value.Length ==0)
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("invalid format");
                }
                else
                {
                    _title = value;
                }
                    
            }
        }

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("invalid format");
                }
                else
                {
                    _author = value;
                }

            }
        }

        public int ISBN { get;}

        public int Copies
        {
            get
            {
                return _copies;
            }
            set
            {
                if(value < 0)
                {
                    Console.WriteLine("invalid nums of copies");
                }
                else
                {
                    _copies = value;
                }
            }
        }
        //public int ISBN { get; private set; }

        //public void setISBN(int value)
        // {
        //     ISBN = value;
        // }

        //public string getTitle()
        // {
        //     return Title;
        // }

        // public void setTitle(string value)
        // {
        //     Title = value;
        // }

        public string displayBook()
        {
            return $"Title:{Title}" +
                $"Author: {Author}" +
                $" ISBN:{ISBN}" +
                $"Copies: {Copies}";
        }

    }
}
