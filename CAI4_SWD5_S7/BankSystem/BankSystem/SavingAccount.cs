using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal class SavingAccount : Account
    {
        public decimal InterestRate { get; set; }

        public override decimal CalcInterestRate()
        {
            return Balance * (InterestRate * 100 / 12);
        }
    }
}
