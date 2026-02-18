namespace Day2
{
    internal class Program
    {


        ////data for book
        //static string[] bookTitles = new string[100]; 
        //static string[] bookAuthors = new string[100];
        //static string[] bookISBNs = new string[100];
        //static int[] copies = new int[100];
        //static int bookCount = 0;


        //// data for users
        //static string[] userName = new string[100];
        //static string[] userBooks = new string[100];
        //static int userCount = 0;

        static void Main(string[] args)
        {
            #region Example

            //AddBook("harry", "sdada", "dadada", 20);

            //Book book = new Book()
            //{
            //    Copies= 10
            //};
            //book.Title = "string.Empty";
            //book.Display();
            ////book.Copies = -20;
            //Console.WriteLine(book.Copies);
            //book.Borrow();


            //Book book2 = new Book();
            //book2.Title = "test";
            //book2.Display();
            //Console.WriteLine(book.Title);
            //book.SetTitle("    ");
            //Console.WriteLine(book.GetTitle());

            //Book book = new Book(); // test
            //book.Title = "sdasdas";
            //Console.WriteLine(book.Title);
            //Console.WriteLine(book.Copies);


            //Book book1 = new Book("casd");
            //Console.WriteLine(book1.Title);

            //Book book = new Book("scacv");



            Book BaseBook = new Book("c#");
            Book book1 = new Book(BaseBook);
            book1.Title = "csdas";
            Book book2 = BaseBook;
            Console.WriteLine(book1.Title);

            #endregion
        }

        //public static void AddBook(string title, string author, string isbn, int copy)
        //{
        //    bookTitles[bookCount] = title;
        //    bookAuthors[bookCount] = author;
        //    bookISBNs[bookCount] = isbn;
        //    copies[bookCount] = copy;
        //    bookCount++;
        //    Console.WriteLine("Book Added");
        //}


        // Self study => private - static - chain
    }
}
