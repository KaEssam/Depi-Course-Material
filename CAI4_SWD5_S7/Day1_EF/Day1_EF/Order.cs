using System;
using System.Collections.Generic;
using System.Text;

namespace Day1_EF
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime orderData { get; set; }



        public ICollection<Product> products { get; set; }
    }
}
