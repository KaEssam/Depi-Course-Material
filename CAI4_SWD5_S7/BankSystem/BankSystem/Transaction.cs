using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal class Transaction
    {
        public TransactionType type { get; set; }
        public decimal Amount { get; set; }
        public DateTime TxDate { get; set; }
        public string Description { get; set; }
    }
}
