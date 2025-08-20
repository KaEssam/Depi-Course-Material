using MNF_S2_Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S2_Day3
{
    class Magazine : LibraryItem,IBuy
    {
        public override string ItemType => throw new NotImplementedException();

        public bool Buy(string itemName)
        {
            throw new NotImplementedException();
        }

        //public override bool Borrow(string MagazineName)
        //{
        //    throw new NotImplementedException();
        //}

        public override void hello()
        {
            Console.WriteLine("magazine");
        }

    }
}
