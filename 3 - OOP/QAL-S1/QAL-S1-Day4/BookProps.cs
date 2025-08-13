using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAL_S1_Day4
{
   partial class Book
    {
        public int Price { get; set; }

        void print()
        {
            Review review = new Review();
            review.rate();
        }

        public class Review
        {

           public void rate()
            {
                Book book = new Book();
                book.Price = 2000;
                Console.WriteLine();
            }
        }
    }
}
