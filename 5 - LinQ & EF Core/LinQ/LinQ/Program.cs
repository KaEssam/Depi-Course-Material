using LibraryManagementSystem;
using LINQ_DATA;

namespace LinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region LinQ
            //method
            //var books = LibraryData.Books.Select(book => book);

            ////query
            //var books2 = from b in LibraryData.Books
            //                            select b;
            //books.ToConsoleTable();
            //books.ToConsoleTable();


            // find all books is avlible and price > 25

            //var expBook = from book in LibraryData.Books
            //                              where book.IsAvailable == true && book.Price > 25
            //                              select book;


            //var cheBook = LibraryData.Books
            //                            .Where(book => book.IsAvailable == true && book.Price < 25)
            //                            .Select(book => book);


            //var cheBook = LibraryData.Books
            //                .Where(book => book.IsAvailable == true && book.Price < 25)
            //                .Select(book => new {book.Title, book.Price} );




            //var cheBook = LibraryData.Books
            //                .Where(book => book.IsAvailable == true && book.Price < 25)
            //                .Select(book => new { book.Title, book.Price })
            //                .OrderBy(book => book.Title)
            //                .OrderBy(book => book.Price);


            //var cheBook = LibraryData.Books
            //      .Select(book => book)
            //      .OrderByDescending(book => book.Title)
            //      .ThenByDescending(book => book.Price)
            //      .Where(book => book.IsAvailable == true && book.Price < 25);




            //foreach (var book in cheBook)
            //{
            //    Console.WriteLine(book.Title);
            //}
            //expBook.ToConsoleTable();

            //cheBook.ToConsoleTable();

            //// genra -  count - total price - avg
            //var genraStats = LibraryData.Books
            //    .GroupBy(book => book.Genre)
            //    .Select(group => new
            //    {
            //        GenreName = group.Key,
            //        BookCount = group.Count(),
            //        Total = group.Sum(book => book.Price),
            //        Avg = Math.Round(group.Average(book => book.Price),2)
            //    });

            ////genraStats.ToConsoleTable();

            //// book name - author - country - btd - publish year

            ////method

            //var BookData = LibraryData.Books
            //    .Join(LibraryData.Authors,
            //    book => book.AuthorId,
            //    author => author.Id, (book, author) => new
            //    {
            //        BookName = book.Title,
            //        AuthorName = author.Name,
            //        author.Country,
            //        author.BirthDate,
            //        book.PublishedYear
            //    });


            ////query

            //var bookDataQuery = from b in LibraryData.Books
            //                    join a in LibraryData.Authors
            //                    on b.AuthorId equals a.Id
            //                    select new
            //                    {
            //                        BookName = b.Title,
            //                        AuthorName = a.Name,
            //                        a.Country,
            //                        a.BirthDate,
            //                        b.PublishedYear
            //                    };

            //BookData.ToConsoleTable("data method");
            //bookDataQuery.ToConsoleTable("data query");


            //var cheBook = LibraryData.Books
            //                            .Where(book => book.IsAvailable == true)
            //                            .Select(book => book);

            //cheBook.ToConsoleTable();

            ////var Book = LibraryData.Books
            ////                            .First(book => book.IsAvailable == true);


            //var Book = LibraryData.Books
            //                       .FirstOrDefault(book => book.Price > 100);

            //Console.WriteLine($"{Book?.Title ?? "Book Not Avalible"}");

            //try
            //{
            //    if (cheBook != null)
            //    {
            //        Console.WriteLine(Book.Title);
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("Book Not Avalible");
            //}


            // 

            //        var bookPage = LibraryData.Books
            //            .Skip(0).Take(5);

            //        bookPage.ToConsoleTable();


            //        var bookPage2 = LibraryData.Books
            //.Skip(5).Take(5);

            //        bookPage2.ToConsoleTable();


            //        var bookPage3 = LibraryData.Books
            //.Skip(10).Take(5);

            //        bookPage3.ToConsoleTable();


            // defferd
            //var num = new List<int> { 1, 2, 3, 4, 5 };

            //var even = num.Where(n =>
            //{
            //    Console.WriteLine($"check {n}");
            //    return n % 2 == 0;
            //});

            //Console.WriteLine("before foeach ");

            //foreach(var n in even)
            //{
            //    Console.WriteLine($"res :{n}");
            //}

            //Console.WriteLine("after foreach");


            // eager 
            //var num = new List<int> { 1, 2, 3, 4, 5 };

            //var even = num.Where(n =>
            //{
            //    Console.WriteLine($"check {n}");
            //    return n % 2 == 0;
            //}).ToList();

            //Console.WriteLine("before toList() ");

            //foreach (var n in even)
            //{
            //    Console.WriteLine($"res :{n}");
            //}

            //Console.WriteLine("after ToList");




            //Console.WriteLine("before");
            //foreach(var n in nums())
            //{
            //    Console.WriteLine($"res {n} ");
            //}
            //Console.WriteLine("after ");

            #endregion

        }

        //public static IEnumerable<int> nums()
        //{
        //    Console.WriteLine("start");
        //    yield return 1;

        //    Console.WriteLine("1");
        //    yield return 2;

        //    Console.WriteLine("2");
        //    yield return 3;

        //    Console.WriteLine("3");
        //    yield return 4;

        //    Console.WriteLine("Finish");

        //}
    }
}
