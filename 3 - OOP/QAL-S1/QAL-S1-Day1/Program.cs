
using QAL_S1_Day1;

class Program
{
  static void Main(string[] argus)
  {
        // //
        // LibraryManager library = new LibraryManager();

        // library.AddBook("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565", 5);
        // // library.AddBook("To Kill a Mockingbird", null, "978-0446310789", -3);
        // library.AddBook("", "George Orwell", "9", 2);

        // library.ShowAllBooks();


        Book book1 = new Book()
        {
            Title = "C#",
            Author = "Ali",
            Copies = 5
        };

        Console.WriteLine(book1.displayBook());
        //book1.Title = "c#";
        //book1.ISBN = 
        //book1.setISBN(123456789);

        //Console.WriteLine(book1.Title);
        //Console.WriteLine(book1.ISBN);
        //book1.setTitle("C#");
        //Console.WriteLine(book1.getTitle());

  }
}



