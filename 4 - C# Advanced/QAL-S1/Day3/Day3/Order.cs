using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public delegate decimal DicountRule(Order order);
    public class Order
    {
        public decimal SubTotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Discount { get; set; }
        public decimal Total => SubTotal + Shipping - Discount;
    }
}
