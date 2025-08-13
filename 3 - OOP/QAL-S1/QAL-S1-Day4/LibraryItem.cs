

//namespace QAL_S1_Day4
//{
//    // c# 8.0
//    // cannot create init
//    // abstract member => must be in abstract class, must be implment in the drived classes
    
//    abstract class LibraryItem
//    {
//        // concerate filed - props (shared implmention)
//        private static string _isbn;
//        protected string _title;
//        private string _category;


//        //validtion
//        public string ISBN { get { return _isbn; } }
//        public string Category { get; set; }

//        // abstrct prop => implment in drived class
//        public abstract string ItemType { get;}
//        public virtual string Title
//        {
//            get { return _title; }
//            set
//            {
//                if (string.IsNullOrEmpty(value))
//                {
//                    Console.WriteLine("invalid");
//                }
//                else
//                {
//                    _title = value;

//                }
//            }
//        }
//        private static int _nextId = 100;

//        private DateTime _createAt;


//        public LibraryItem()
//        {
//            Console.WriteLine("Default base Constructor");
//            _isbn = GenerateId();
//            _createAt = DateTime.Now;
//            Console.WriteLine(ISBN);
//            Console.WriteLine(_createAt);
//        }

//        public LibraryItem(string title, string catrgory) : this()
//        {
//            Console.WriteLine("Paramterized base contructor");
//            Title = title;
//            Category = catrgory;
//        }

//        //shared implmention
//        public virtual void DisplyInfo()
//        {
//            Console.WriteLine($"ID: {ISBN}");
//            Console.WriteLine($"Title: {Title}");
//        }

//        private static string GenerateId()
//        {
//            _nextId++;
//            return  $"ISBN{_nextId:D5}";
//        }

//        // shared contract method => must drived class make implment for it 
//        public abstract void hello();


//        protected abstract bool Borrow(string itemName);

//        //protected abstract bool Renew();

//    }
//}
