namespace MNF_S1_Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Book book1 = new Book();
            //Book book2 = new Book();
            //book1.Tilte = "";

            //book1.setTitle("");

            //Console.WriteLine(book1.Tilte);
            //Console.WriteLine(book1.getTitle
            //
            //book1.Title = "";
            //Console.WriteLine(book1.Title);

            //Console.WriteLine(Book.Max_Copies);

            //book1.CreateAt = DateTime.Now;

            //book1.setISBN(123456);
            //Console.WriteLine(book1.ISBN);

            //book1.PublishYear = Convert.ToDateTime("1970-01-01");
            ////Console.WriteLine(book1.BookAge());

            //Console.WriteLine(book1.BookAge);
            //Console.WriteLine(book1.BookDescription);


            //Book book1 = new Book(3, 4);

            //book1.test1 = 1;
            //book1.Test2 = 2;
            //book1.Test3 = 3;
            //book1.Test4 = 4;

            Book book1 = new Book();
            Book book2 = new Book();
            Book book3 = new Book();
            Book book4 = new Book("c#", "Ali", 123456);
            Book book11 = book4;
            Book book5 = new Book(book4);
            Book book6 = new Book(book4);
            Book book7 = new Book(book4);
            Book book8 = new Book(book4);
            Book book9 = new Book(book4);
            Book book10 = new Book(book4);


        }

    }
}
