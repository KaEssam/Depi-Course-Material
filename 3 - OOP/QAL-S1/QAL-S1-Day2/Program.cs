namespace QAL_S1_Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Data parse

            //int a = 5;
            //long b = a;


            //long c = 200;
            //int d =(int)c;


            // convert  => all datatype

            //string str = "123";
            //double num = Convert.ToDouble(str);

            // parse => numeric data types

            //string str = "abc";
            //double num = double.Parse(str);
            //Console.WriteLine(num);

            // try parse

            //string str = "123";

            //if(int.TryParse(str, out int num))
            //{
            //    Console.WriteLine($"{num}");
            //}
            //else
            //{
            //    Console.WriteLine("cannot convert");
            //}

            //Console.WriteLine(sizeof(bool));
            //Console.WriteLine(sizeof(int));
            //int result =int.TryParse(str, out int num);
            //Console.WriteLine(num);

            #endregion

            //Book book1 = new Book(123,"cairo");
            //Book book2 = new Book(123, "sdsd");

            //book1.ISBN = 255;
            //book1.setISBN(123);
            //Console.WriteLine(book1.ISBN);
            //Console.WriteLine(book1.info);
            //book2.info();


            //book1.setTitle("cwc");
            //Console.WriteLine(book1.getTitle());


            //Book book1 = new Book("c# nut",12321212);
            //Book book2 = new Book(book1);
            //Book book3 = new Book(book1);
            //Book book4 = new Book(book1);
            //Book book5 = new Book(book1);


            Book book2 = new Book();
            Book book3 = new Book();

            Console.WriteLine(Book._copies);


            // health = 100 


        }
    }
}
