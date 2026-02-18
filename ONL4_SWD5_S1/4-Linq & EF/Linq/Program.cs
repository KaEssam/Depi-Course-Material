

//var 

//var x = 10;
//x = "sdasd";


//anonymos type

//var user = new { name = "karim", age =19 };
//var user1 = new { name = "karim", age = 19, salary = 4210 };
//user.name = "sdsad";

using LibraryManagementSystem;
using LINQ_DATA;


//var res = new List<Book>(); 

//foreach(var book in LibraryData.Books)
//{
//    if(book.Genre == "Programming" && book.Price > 40)
//    {
//        res.Add(book);
//    }
//}


//foreach(var book in res) // 4 books 
//{
//    Console.WriteLine($"{book.Title} - {book.Price}");
//}

//Console.WriteLine("====================================");

//IQueryable<Book> result = LibraryData.Books.Where(b => b.Genre == "Programming" && b.Price > 40);
//IEnumerable<Book> result1 = LibraryData.Books.Where(b => b.Genre == "Programming" && b.Price > 40);


//foreach (var book in result)
//{
//    Console.WriteLine($"{book.Title} - {book.Price}");
//}


//==============================================================================


// QUERY SYNTAX


//var BOOKS = from book in LibraryData.Books
//            where book.IsAvailable == true && book.Genre == "Programming"
//            select new {book.Title, book.Price, book.Genre};


//var books = LibraryData.Books.Where(b => b.Genre == "Programming" && b.IsAvailable == true)
//    .Where(b=>b.IsAvailable == false)
//    .Select(b => new { b.Title, b.Genre, b.Price, });

//BOOKS.ToConsoleTable();
//Console.WriteLine("===========================");
//books.ToConsoleTable();



var books = LibraryData.Books
    .Select(b => new { bookTitle = b.Title, b.Genre, b.Price, BookAge = DateTime.Now.Year - b.PublishedYear })
    .OrderBy(b => b.Price).ThenBy(b => b.BookAge).ToList();
//books.ToConsoleTable();


// first / firstordefault 

//var firstBook = LibraryData.Books.First(b=> b.Genre == "Programm");
//var firstBook = LibraryData.Books.FirstOrDefault(b=> b.Genre == "Programmin");


//Console.WriteLine(firstBook.Title);


//any / all / count

////var hasBooks = LibraryData.Books.Any(b => b.Genre == "Programming"); //true
//var hasBooks = LibraryData.Books.All(b => b.Title.Length > 0); //true
//Console.WriteLine(hasBooks);
var bookcount = LibraryData.Books.Count(b => b.Genre == "Programming");
//Console.WriteLine(bookcount);


// group by

//var groupStats = LibraryData.Books.GroupBy(b => b.Genre)
//    .Select( g=> new
//    {
//        Genra = g.Key,
//        count = g.Count(),
//        totalPrice = g.Sum(g=> g.Price),
//        avgPrice = g.Average(g=> g.Price),
//        bookExp = g.Max(g=> g.Price),
//        cheapestBook = g.Min(g=> g.Price),
//    });

//groupStats.ToConsoleTable();

//

//int pageSize = 5;
//int pageNum = 3;


//var books = LibraryData.Books.Skip((pageNum - 1)* pageSize).Take(pageSize);
//books.ToConsoleTable();

// join


//var BookAuthor = from book in LibraryData.Books
//                 join author in LibraryData.Authors on book.AuthorId equals author.Id
//                 select new
//                 {
//                     book.Title,
//                     author.Name,
//                     book.Genre,
//                     book.Price,
//                 };


//BookAuthor.ToConsoleTable();


//var authorBook = LibraryData.Books.Join(LibraryData.Authors, book => book.AuthorId, author => author.Id,
//    (book, author) => new
//    {
//        book.Title,
//        author.Name,
//        book.Genre,
//        book.Price,
//    }).ToList();

//authorBook.ToConsoleTable();


//static IEnumerable<Book> getBook(List<Book> books)
//{
//    var res = new List<Book>();

//    foreach (var book in books)
//    {
//        if (book.Genre == "Programming" && book.Price > 40)
//        {
//            res.Add(book);
//        }
//    }
//    return res;
//}


static IEnumerable<Book> getBook(List<Book> books)
{

    foreach (var book in books)
    {
        if (book.Genre == "Programming")
        {
            yield return book;
        }
    }
}

var books2 = getBook(LibraryData.Books);

books.ToConsoleTable();