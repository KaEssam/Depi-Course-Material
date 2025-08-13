using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNF_S1_Day4
{
    interface IBorrowable
    {

        bool IsAvailable { get;}
        bool Borrow(string ItemName);
        bool Return();

        
    }
}
