namespace MNF_S2_Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region

            //passing by value
            //int x = 10;


            //void addFive(ref int num)
            //{
            //    num += 5;
            //}

            //Console.WriteLine(x); //10
            //addFive(ref x); //15
            //Console.WriteLine(x);//10

            //void info(out string n, string l)
            //{
            //    n = "n";
            //    l = "l";
            //}

            //string x;
            //info(out x, "s");
            //Console.WriteLine(x);


            ////Console.WriteLine(n);

            //string str = "123";

            //bool result = int.TryParse(str, out int num);

            //Console.WriteLine(num);


            //int sum(params int[] nums)
            //{
            //    int result = 0;

            //    foreach (int n in nums)
            //    {
            //        result += n;
            //    }
            //    return result;
            //}

            ////int[] numbers = { 1, 2, 3, 4, 5 };


            //Console.WriteLine(sum(1,20,50,90));





            #endregion

            //Book book1 = new Book("cairo", "mnf");

            //book1.Title = " ";

            //Console.WriteLine(book1.Title);


            //book1.setTitle(" ");
            //Console.WriteLine(book1.getTitle());

            //book1.Title = "c#";
            //Console.WriteLine(book1.Title);

            //book1.Title = "amr khaled";
            //Console.WriteLine(book1.Title);

            //book1.Branch = ""
            //book1.Name = "";

            //book1.Autor =""

            //Book book1 = new Book()
            //{
            //    Year = 2000
            //};
            //book1.Year = 

            //Console.WriteLine(book1.Year);


            ////book.BorrowBooks = 20;
            //book.PublishYear = Convert.ToDateTime("1980-01-01");
            //Console.WriteLine(book.BookAge);

            Book book1 = new Book(); // 1
            Book book2 = new Book(); // 2
            Book book3 = new Book(); // 3
            Book book4 = new Book("500", "20", 20); // 3
            //Book book20 = book4;
            //book20.Title = "ali";
            //Console.WriteLine(book4.Title);
            //Console.WriteLine(book20.Title);
            Book book5 = new Book(book4);
            //book5.Title = "ahemd";
            //Console.WriteLine(book5.Title);
            Book book6 = new Book(book4);
            Book book7 = new Book(book4);
            Book book8 = new Book(book4);
            Book book9 = new Book(book4);
            Book book10 = new Book(book4);
            Book book11 = new Book(book4);
            Book book12 = new Book(book4);
            Book book13 = new Book(book4);
            Book book14 = new Book(book4);
            Book book15 = new Book(book4);
            Book book16 = new Book(book4);




        }
    }
}
