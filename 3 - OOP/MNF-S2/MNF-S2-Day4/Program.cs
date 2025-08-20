using MNF_S2_Day3;

namespace MNF_S2_Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LibraryItem magazine = new Magazine();
            //magazine.hello();

            //LibraryItem item = new LibraryItem(); error

            //Console console = new Console();
            //Console.WriteLine(Math);
            //StaticClass.hello();
            //StaticClass.hello();
            //StaticClass.hello();
            //StaticClass.hello();
            //StaticClass.hello();

            //Console.WriteLine();
            //Random random = new Random();
            //Console.WriteLine(random.Next(10, 100));

            //Book book = new Book();
            //book.Id = 10;
            //book.print();

            Novel novel = new Novel();
            novel.Id = 10;
            novel.NovelRate();
            

            //Novel.review.Rate();
        }

        
    }

    class ConcretClass
    {
        // prop , field
        // ctor 
        // methods
        // static members
    }

    abstract class AbstractClass
    {
        // prop , field
        // ctor 
        // methods
        // static members
        //abstract members
    }


    //uploadFile()
    static class StaticClass
    {
        // must be static members
        public static int MyProperty { get; set; }

        static StaticClass()
        {
            Console.WriteLine("static");
        }


        public static void hello()
        {
            Console.WriteLine("hello from static");
        }
    }


    sealed class SealedClass : AbstractClass
    {
        public int Id { get; set; }
    }

   //partial class Book
   // {
   //     public  int Id { get; set; }    
   // }

   //partial class Book
   // {
   //     public void print()
   //     {
   //         Console.WriteLine(Id);
   //     }
   // }

    //DTO => CREATE EMP DTO, UPDATE EMP DTO, RESPONSE EMP DTO
    // DTO => EMP 
   public class Novel
    {
        public  int Id { get; set; }

        public void NovelRate()
        {
            review review = new review();
            review.Rate(Id); 
        }


        public class review
        {
            public void Rate(int id)
            {
                Console.WriteLine($"high rate {id}");
            }
        }
    }


    // OBJ RELATION 

    //inheritanc
    // association
    // aggregation 
    // composition 

    class book1
    {
        public List<Author> authors { get; set; }
        public int LibraryId { get; set; }
        public  Library library { get; set; }
    }

    class Library
    {
        public  List<book1> Book1s { get; set; }
    }

    class Author
    {

        public List<book1> Book1s { get; set; }
    }


    //self study(struct, opertor overload, distructor, disposable)
}
