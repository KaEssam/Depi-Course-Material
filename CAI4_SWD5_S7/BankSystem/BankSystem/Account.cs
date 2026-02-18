using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public delegate void Notify(string msg);
    internal abstract class Account
    {
        private static int _nextNum;
        public int AccountNum { get; private set; }
        public DateTime OpenedDate { get; }
        public decimal Balance { get; protected set; }

        public Notify notify { get; set; }
        public List<Transaction> transactions { get; set; } = new();

        protected Account()
        {
            AccountNum = _nextNum++;
            OpenedDate = DateTime.Now;
            Balance = 0;
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;

            //TODO: SAVE TX
            AddTransaction(TransactionType.Deposit, amount,DateTime.Now,
                $"Deposit from {AccountNum} - {amount}, Balance{Balance}");

            //TODO: NOTIFICATION
            notify.Invoke($"Deposit from {AccountNum} - {amount}, Balance{Balance}");
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (Balance < 0 || amount > Balance)
                return false;

            Balance -= amount;

            TransactionHelper.AddTransaction(transactions, TransactionType.Deposit, amount, DateTime.Now,
            $"Deposit from {AccountNum} - {amount}, Balance{Balance}");

            return true;

       
            //TODO: NOTIFICATION
        }

        public abstract decimal CalcInterestRate();

        protected void AddTransaction(TransactionType type, decimal amount, DateTime date, string desc)
        {
            transactions.Add(new Transaction()
            {
                type =type,
                Amount = amount,
                TxDate = date,
                Description = desc
            });
        }
    }
}
