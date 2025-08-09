
using MNF_S2_Day3;

namespace MNF_S2
{
   class EBook : LibraryItem
    {
        public string Author { get; set; }

        //public override string Title { get{ return _title; } set {
        //        if (string.IsNullOrWhiteSpace(value))
        //        {
        //            Console.WriteLine("ebook title invalid");
        //        }
        //        else
        //        {
        //            _title = value;
        //        }

        //    } }
        public EBook() :base()
        {
            Console.WriteLine("Default ebook constructor"); 
        }

        public override void DisplyInfo()
        {
            Console.WriteLine($"id: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Title: {Author}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Created At: {_CreateAt}");
        }

        public override string ToString()
        {
            return $"Title:{Title} by {Author}, price:{Price}";
        }
    }
}
