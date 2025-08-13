//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MNF_S1_Day3
//{
//    class Magazine : LibraryItem
//    {
//        //public string Title { get; set; }
//        //public int BookId { get; set; }
//        //public decimal Price { get; set; }
//        //public string Category { get; set; }

//        bool isAvailable = true;

//        public override string ItemType => throw new NotImplementedException();

//        public bool Borrow(string BookName)
//        {
//            if (!isAvailable)
//            {
//                return false;
//            }
//            else
//            {
//                isAvailable = false;
//                return true;
//            }

//        }

//        public override bool Borrow(string ItemName)
//        {
//            throw new NotImplementedException();
//        }

//        public override void displayINfo()
//        {
//            throw new NotImplementedException();
//        }

//        public override void hello()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
