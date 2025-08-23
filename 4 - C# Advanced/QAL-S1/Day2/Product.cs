using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Product
    {
        public delegate bool ProductFilterDel(Product p);
        public delegate decimal Calc(Product p);

        public string Name { get; set; }
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public static List<Product> filter(List<Product> products, ProductFilterDel filterDel)
        {
            List<Product> res = new List<Product>();

            foreach (var p in products)
            {
                if (filterDel(p))
                {
                    res.Add(p);
                }
            }
            return res;

        }


        //public static bool filterPrice(Product p)
        //{
        //    return p.Price > 2000;
        //}

        
    }
}
