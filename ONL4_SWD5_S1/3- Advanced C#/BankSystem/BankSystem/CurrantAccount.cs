using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal sealed class CurrantAccount : Account,IReportable
    {
        public decimal Overdarft { get; set; }

        public CurrantAccount(decimal overdraft)
        {
            Overdarft = overdraft;
        }
        public override string AccountType() => "Currant";

        public override decimal CalculateMonthlyInterset() => 0;

        public string GetReport()
        {
            return $"Currant Account Report" +
                $"Account: {AccountNumber}" +
                $"Balance: {Balance} EGP" +
                $"OverDarft: {Overdarft}" +
                $"Transaction : {transctions.Count}";
        }
    }
}
