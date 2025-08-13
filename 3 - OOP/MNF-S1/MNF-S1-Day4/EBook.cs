using MNF_S1_Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S1_Day3
{
    class EBook : LibraryItem, IBorrowable
    {
        //public override string ItemType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public override string ItemType => "EBook";
        public override string ItemType { get { return "EBook"; } }

        public bool IsAvailable => true;

        public override bool Borrow(string ItemName)
        {
            throw new NotImplementedException();
        }

        public override void displayINfo()
        {
            throw new NotImplementedException();
        }

        //public string Title { get; set; }
        //public int EBookId { get; set; }
        //public decimal Price { get; set; }
        //public string Category { get; set; }

        //public override string ToString()
        //{
        //    return $"Book:{Title} by {Author}";
        //}
        public override void hello()
        {
            throw new NotImplementedException();
        }

        public bool Return()
        {
            throw new NotImplementedException();
        }
    }
}
