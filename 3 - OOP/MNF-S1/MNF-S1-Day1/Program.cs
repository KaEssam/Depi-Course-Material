using System;
using MNF_S1_Day1;

class Program
{
  static void Main(string[] args)
  {
    #region PROCEDURAL PROGRAMING

    // Console.WriteLine("Hello, World!");
    //
    // LibraryManager library = new LibraryManager();
    //
    // library.AddBook("c#","ahmed","dadada",5);
    // library.AddBook("c#","ahmed","dadada",5);
    // library.AddBook("c#","ahmed","1",-50);
    // library.AddBook("","","1",-50);
    // library.AddBook(null,null,null,50);
    //
    // library.ShowAllBooks();
    //
    // library.AddUser("ahemd","dadada",1);
    // library.AddUser("karim","dadada",1);
    // library.AddUser("","",1);
    //
    // library.ShowAllUsers();
    //
    // library.BorrowBook(0,0);
    //
    // library.ShowAllBooks();
    // library.ShowAllUsers();

    #endregion

    
    // string x = " ";
    // if (x==" ")
    //   Console.WriteLine("ok");
    // Console.WriteLine("no");


    Book book1 = new Book();

    // book1.Isbn = 1478963250;
    book1.setIsbn(1234567890);

    // book1.Title = " ";
    // book1.author = null;
    // book1.isbn = 123456789;

    
    book1.DisplayInfo();
    // Console.WriteLine(book1.IsAvailable());
    
    // Book book2 = new Book();
    //
    // book2.title = "C";
    // book2.author = "Ali";
    // book2.isbn = 123456780;
    //
    // book2.DisplayInfo();
    
    
    
  }
}

