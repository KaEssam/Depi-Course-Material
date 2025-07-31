using MNF_S2_Day1;

class Program
{
    static void Main(string[] args)
    {

        #region Procducer programing
        // LibraryManager library = new LibraryManager();

        // library.AddBook("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565", 1);
        // library.AddBook("To Kill a Mockingbird", "Harper Lee", "978-0446310789", 3);
        // library.AddBook("", "George Orwell", "978", -50);
        // library.AddBook("", null, "978", -50);

        // library.ShowAllBooks();

        // library.AddUser("ahmed", "dsds", 1);
        // library.AddUser("", "dsds", 1);

        // // library.ShowAllUsers();

        // library.BorrowBook(0, 0);
        // library.BorrowBook(1, 0);


        // // library.ShowAllUsers();

        // library.CorruptData();

        // // library.ShowAllUsers();
        // // library.ShowAllBooks();
        // // library.ShowProblems();
        // // library.ShowSolution();
        #endregion


        //Book book1 = new Book();

        //book1.Title = 4242;

        //Console.WriteLine(book1.Title);
        //book1.Author = "ahmed";
        //book1.ISBN = 123456;
        //book1.Copies = 5;

        //book1.setTitle("c#");

        //Console.WriteLine(book1.getTitle());


        //book1.DisplayBookInfo();

        Book book2 = new Book("","ali the king of c#",-5);
        book2.ISBN =
        book2.setISBN(45542452);
        //book2.Title = "";
        //book2.Author = null;
        //book2.ISBN = 1234566556;
        //book2.Copies = -50;


        book2.DisplayBookInfo();







    }

}
