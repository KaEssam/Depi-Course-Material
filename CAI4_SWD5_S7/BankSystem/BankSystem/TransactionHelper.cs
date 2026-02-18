using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal static class TransactionHelper
    {
        public static void AddTransaction(List<Transaction> transactions, TransactionType type, decimal amount,DateTime date, string desc)
        {
            transactions.Add(new Transaction()
            {
                type = type,
                Amount = amount,
                TxDate = date,
                Description = desc
            });
        }
    }
}
