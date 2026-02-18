using System;
using System.Collections.Generic;
using System.Text;

namespace Day4
{
    internal interface IWrite
    {
        public string type { get; set; }

        void Write();
    }
}
