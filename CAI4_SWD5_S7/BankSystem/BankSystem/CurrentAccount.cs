using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal class CurrentAccount: Account
    {
        public decimal OverDraft { get; set; }

        public override decimal CalcInterestRate() => 0;
        
    }
}
