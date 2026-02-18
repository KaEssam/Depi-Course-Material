using LibraryManagementSystem;
using LINQ_DATA;
using System.Collections;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LibraryData.Books.ToConsoleTable("All Books");

            //// var 
            //var x =10;
            ////x = "sds";

            ////var books = new List<Book>();

            //var user = new { name = "karim", role = "instrucotr" };
            //var admin = new { role = "admin", name = "karim"};
            ////user.name = "dasdas";

            //var book = LibraryData.Books.Select(book => new
            //{
            //    book.Title,
            //    book.Price
            //});


            ///

            //METHOD
            //var books = LibraryData.Books;
            //books.ToConsoleTable();

            //var books = LibraryData.Books.Where(book => book.IsAvailable == true && book.Genre == "Programming");
            //books.ToConsoleTable();

            //var books = LibraryData.Books.Where(book => book.IsAvailable == true && book.Genre == "Programming");
            //books.ToConsoleTable();


            // 28 books => 10 books => titles => genre price???
            //var books = LibraryData.Books.Where(book => book.IsAvailable == true)
            //    .Select(book =>new {book.Title, book.Genre, book.Price}).ToList();

            //var dadsa = LibraryData.Books.Select(book => $"Book Title: {book.Title}");


            //var books = LibraryData.Books.Where(book => book.IsAvailable == true && book.Genre == "Programming")
            //    .Select(book =>book.Title);
            //books.ToConsoleTable("dsds");

            //foreach (var book in dadsa)
            //{
            //    Console.WriteLine(book);
            //}

            // List<int> ints1 = new List<int>() { 1,2,3,4,5,6};

            //test(ints1);
            ////QUERY


            //IEnumerable<int> ints = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 
            //test(ints);

            //var point = new Point(1, 2, 3);
            //foreach (int coordinate in point)
            //{
            //    Console.Write(coordinate);
            //    Console.Write(" ");
            //}
            //IQueryable


            //=========================================================================

            //var books = LibraryData.Books.OrderBy(b => b.Title).OrderBy(b => b.Genre).ToList();
            //var books = LibraryData.Books.OrderBy(b => b.Title).ThenBy(b => b.Genre).ToList();
            //var books = LibraryData.Books.ToList();
            //books.ToConsoleTable("bookorders");

            //var first = LibraryData.Books.First(b => b.Price > 200);
            //var first = LibraryData.Books.FirstOrDefault(b => b.Price == 50);
            //var first = LibraryData.Books.Single(b => b.Price > 200);
            //var first = LibraryData.Books.SingleOrDefault(b => b.Price == 50);
            //Console.WriteLine(first.Title);


            //var genraBooks = LibraryData.Books.GroupBy(b => b.Genre)
            //    .Select(group => new
            //    {
            //        genra = group.Key,
            //        BookCount = group.Count(),
            //        TotalPrice = group.Sum(p  => p.Price)
            //    });
            //genraBooks.ToConsoleTable();


            //var AuthorBook = LibraryData.Books.Join(LibraryData.Authors,
            //    book => book.AuthorId,
            //    author => author.Id,
            //    (book, author) => new
            //    {
            //        book.Title,
            //        author.Name
            //    }).ToList();


            //var authorBooKQuery = from book in LibraryData.Books
            //                      join author in LibraryData.Authors on book.AuthorId equals author.Id
            //                      select new
            //                      {
            //                        book.Title, author.Name
            //                      };  

            //AuthorBook.ToConsoleTable();
            //authorBooKQuery.ToConsoleTable();


            //
            //var bookYear = LibraryData.Books.GroupBy(b => b.PublishedYear/10)
            //    .Select(b => new
            //    {
            //       key = b.Key*10,
            //       books = b.ToList(),
            //    });

            //foreach(var book in bookYear)
            //{
            //    Console.WriteLine(book.key);
            //    foreach(var book2 in book.books)
            //    {
            //        Console.WriteLine(book2.Title);
            //    }
            //}

            //bookYear.ToConsoleTable();

            var bookCustomer = from members in LibraryData.Members
                               join loan in LibraryData.Loans on members.Id equals loan.MemberId
                               join book in LibraryData.Books on loan.BookId equals book.Id
                               //where loan.ReturnDate == null
                               select new
                               {

                                   members.FullName,
                                   book.Title,
                                   bookStatus = loan.ReturnDate.ToString() ?? "not returned"
                               };

            bookCustomer.ToConsoleTable();

        }
        //public static void Example()
        //{
        //    var point = new Point(1, 2, 3);
        //    foreach (int coordinate in point)
        //    {
        //        Console.Write(coordinate);
        //        Console.Write(" ");
        //    }
        //    // Output: 1 2 3
        //}

        //public readonly record struct Point(int X, int Y, int Z)
        //{
        //    public IEnumerator<int> GetEnumerator()
        //    {
        //        yield return X;
        //        yield return Y;
        //        yield return Z;
        //    }
        //}
    }
}
