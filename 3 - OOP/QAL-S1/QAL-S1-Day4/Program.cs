
namespace QAL_S1_Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EBook book = new EBook("c#","coding","ali");
            //book.DisplyInfo();//
            //Console.WriteLine(book.ItemType);

            //Console.WriteLine();

            //IBorrowable borrowable = new IBorrowable();

            //LibraryItem library = new LibraryItem();

            //staticClass staticClass = new staticClass(); 

            //staticClass.Hello();

            //IBook book = new IBook();
            //Console.WriteLine(book.ISBN = 123);
            //book.hello();

            Book book = new Book();
            book.hello();

        }
    }


    // Conceret class =>  like entity

    class test
    {
        // field
        // props
        // consturctor
        // methods
        // static members
        // error with abstruct members
        //public abstract void hello();
    }

    // abstruct Class => base class with common implmention and every drived class has his own implemnt if abstruct memebers
    abstract class abstructClass
    {
        // field
        // props
        // consturctor
        // methods
        //static members
        //abstruct members
    }

    //static =>  cannot be init
    static class staticClass
    {
        // upload (file, name)
        // key => 
        // all memebers must be static
        public static void Hello()
        {
            Console.WriteLine("hello");
        }
    }

   sealed class  SealedClass
    {
        void sealedMehtod()
        {
            Console.WriteLine("sealed");
        }
    }


    partial class IBook
    {
        // FIELD , PROPS
        public int ISBN { get; set; }
    }

    partial class  Catalog
    {
      public  void hello()
        {
            Console.WriteLine("hello");
        }

        public List<Library> libraries { get; set; }
    }


    class Library
    {
        public Catalog catalog; // aggregation
        public Book books { get; set; } // COMPOSITION 
        public List<Catalog> catalogs { get; set; }
    }

}


//(IS-A) (HAS-A)
// IS-A => INHERITANCE  (TIGHT COUPLING)

// ASSOCITION   BOOK AND USER?
// Aggregation  catalog and library 
// Composition  Library and Book (LOOSE COUPLING)


// user- books - author- library

// self study(operator overload - Destructor- IDisposable,struct)

// 
