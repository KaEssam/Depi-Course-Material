using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAL_S1_Day4
{
    interface IBorrowable
    {
        bool IsAvaliabel { get; }
        bool Borrow(string borrowName);
        bool Return();

    }
}
