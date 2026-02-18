using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal sealed class SavingAccount: Account, IReportable
    {

        public decimal IntersetRate { get; set; }

        public override string AccountType() => "Saving";
        

        public override decimal CalculateMonthlyInterset()
        {
            return Balance * IntersetRate / 100 / 12;
        }

        public string GetReport()
        {
            return $"Saving Account Report" +
                $"Account: {AccountNumber}" +
                $"Balance: {Balance} EGP" +
                $"Interset Rate%: {IntersetRate}%" +
                $"Monthly Interst: {CalculateMonthlyInterset()} EGP" +
                $"Transaction : {transctions.Count}";
        }
    }
}
