namespace Day2
{
    internal class Program
    {

      //static string[] bookTitles = new string[100];

      //static string[] bookAuthors = new string[100];

      //static int[] bookCopies = new int[100];

      //static int bookCount = 0;


        static void Main(string[] args)
        {
            //AddBook("c#","c", 5);
            //DisplayBook();
            //Console.WriteLine(FindBookByTitle("c#"));
            //Console.WriteLine(FindBookByAuthor("c"));


            //Book book = new Book();
            //book.Title = "C#";
            //book.Author = "Karim";
            //book.Copies = 2;

            //Console.WriteLine(book.Title);
            //Console.WriteLine(book.Author);
            //Console.WriteLine(book.Copies);
            //book.Display();

            //Book book1 = new Book();
            //book1.Title = "J#";
            //book1.Copies = 1;
            //book1.Display();

            //Book abdo = new Book();
            //Console.WriteLine(abdo.Title);


            //Book book = new Book("c#");
           
            //Console.WriteLine(book.Title);
            ////book.Title = "c#";
            ////Console.WriteLine(book.Title);
            ////book.SetTitle("c#");
            ////Console.WriteLine(book.GetTitle());
            //book.Copies = 1;
            //Console.WriteLine(book.Copies);

            Book book1 = new Book();
            book1.Display();

            Book book2 = new Book("c","cadca");
            Book book = new Book(book2);
            Book book7 = book2;



            book.Display();
            Book book6 = new Book(book2);
            book6.Display();
            Book book5 = new Book(book2);
            book5.Display();
            Book book3 = new Book(book2);
            book3.Display();
            Book book4 = new Book(book2);
            book4.Display();
            book2.Display();

            ///

            // self study => private , static , chain (constructor)

        }


        #region old way
        //public static void AddBook(string title, string author,int copy)
        //{
        //    bookTitles[bookCount] = title;
        //    bookCopies[bookCount] = copy;
        //    bookAuthors[bookCount] = author;
        //    bookCount++;
        //    Console.WriteLine("Book Added");

        //}

        //public static void DisplayBook()
        //{
        //    for(int i = 0; i < bookCount; i++)
        //    {
        //        Console.WriteLine($"Title:{bookTitles[i]},Author:{bookAuthors[i]}, copies{bookCopies[i]}");
        //    }
        //}

        //public static int FindBookByTitle(string title)
        //{
        //    for( int i = 0;i < bookCount; i++)
        //    {
        //        if( bookTitles[i] == title)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}


        //public static int FindBookByAuthor(string author)
        //{
        //    for (int i = 0; i < bookCount; i++)
        //    {
        //        if (bookAuthors[i] == author)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        #endregion
    }
}
