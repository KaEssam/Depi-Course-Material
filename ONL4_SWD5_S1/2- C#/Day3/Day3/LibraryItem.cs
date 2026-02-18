using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    internal class LibraryItem
    {
        protected string _name;
        public string Id { get;} //ISBN00000
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get;}

        private static int itemNum = 0;

        public virtual void Info()
        {
            Console.WriteLine($"Title: {Title}, Description: {Description}, Category: {Category}");
        }

        public LibraryItem()
        {
            Console.WriteLine("Base CTOR");
            CreatedAt = DateTime.Now;
            Id = GenerateId();

        }

        public LibraryItem(string title):this()
        {
            Title = title;
            Console.WriteLine($"Item Added !!, id:{Id}, title: {Title}, create at: {CreatedAt}");
        }

        private static string GenerateId()
        {
            return $"ISBN{++itemNum:D5}";
        }
    }
}
