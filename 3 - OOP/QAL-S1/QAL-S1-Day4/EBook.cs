

//namespace QAL_S1_Day4 
//{
//    class EBook : LibraryItem
//    {

//        public string Author { get; set; }

//        public override string Title { get { return _title; } set {
//                if (string.IsNullOrEmpty(value))
//                {
//                    Console.WriteLine("invalid title ebook");
//                }
//                else
//                {
//                    _title = value;

//                }
//            } }

//        public override string ItemType =>"Ebook";

//        public EBook() : base()
//        {
//            Console.WriteLine("default ebook constructor ");
//        }

//        public EBook(string title, string category, string author) :base(title,category)
//        {
//            Console.WriteLine("paramtarized ebook constructor");

//            //if (string.IsNullOrEmpty(title))
//            //{
//            //    Console.WriteLine("invalid");
//            //}
//            //else
//            //{
//            //    Title = title;

//            //}
//            //Category = category;
//            Author = author;
//        }

//        //public override void DisplyInfo()
//        //{
//        //    Console.WriteLine($"ID: {ISBN}");
//        //    Console.WriteLine($"Title: {Title}");
//        //    Console.WriteLine($"category: {Category}");
//        //    Console.WriteLine($"category: {Author}");
//        //}


//        public override string ToString()
//        {
//            return $"id:{ISBN},Title: {Title} by {Author}";
//        }

//        public override void hello()
//        {
//            throw new NotImplementedException();
//        }

//        protected override bool Borrow(string itemName)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
