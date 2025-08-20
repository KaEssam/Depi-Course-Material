using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S2_Day4
{
    interface IBorrowable
    {

        bool isAvaliable { get; set; }
        bool Borrow(string itemName);
        bool Return();
    }
}
