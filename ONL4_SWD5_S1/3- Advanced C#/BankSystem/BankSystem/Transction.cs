using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal class Transction
    {
        public decimal Amount { get; set; }
        public TranscationType Type { get; set; }
        public DateTime date { get; set; }

        public string Descripton { get; set; }

    }
}
