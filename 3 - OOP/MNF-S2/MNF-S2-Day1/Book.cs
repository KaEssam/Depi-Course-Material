using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MNF_S2_Day1
{
    public class Book
    {
        // fields => data storage
        private string _title;
        private string _author;
        private int _isbn;
        private int _copies;


        public Book(string title, string author, int copies)
        {
            Author = author;
            Title = title;
            Copies = copies;
            //ISBN = isbn;
        }

        //public string getTitle()
        //{
        //    return _title;
        //}

        //public void setTitle(string value)
        //{
        //    if(value == null)
        //    {
        //        Console.WriteLine("invalid title format");
        //    }
        //    else
        //    {
        //        _title = value;
        //    }
        //}

        //properties => data access 
        public string Title {
            get
            {
                return _title;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("invalid title format");
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
                    Console.WriteLine("invalid title format");
                }
                else
                {
                    _author = value;
                }
            }
        }

        public int ISBN { get; private set; }

        public void setISBN(int ISBND)
        {
            ISBN = ISBND;
        }
        //public int ISBN {
        //    get
        //    {
        //        return _isbn;
        //    }

        //    set
        //    {
        //        if (Convert.ToString(value).Length == 10)
        //        {
        //            _isbn = value;
        //        }
        //        else
        //        {
        //            Console.WriteLine("valid isbn");
        //        }
        //    }
        //}
        public int Copies {
            get
            {
                return _copies;
            }

            set
            {
                if(value <= 0)
                {
                    Console.WriteLine("enter greater num");
                }
                else
                {
                    _copies = value;

                }
            } 
        }

        // bouns => handel 
        public void DisplayBookInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Copies: {Copies}");
            Console.WriteLine("------------------------");
        }
    }

}
