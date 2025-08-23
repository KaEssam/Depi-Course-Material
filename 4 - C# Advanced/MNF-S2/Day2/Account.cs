using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public delegate void TransactionHandler(string msg);
    class Account
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public TransactionHandler transaction;

        public event TransactionHandler TransactionHandlerEvent;

        public void Deposit( decimal amount)
        {
            Balance += amount;
            //Console.WriteLine($"{Name}: Deposite {amount}, Balance {Balance}");
            transaction.Invoke($"{Name}: Deposite {amount}, Balance {Balance}");
            //TransactionHandlerEvent.Invoke($"{Name}: Deposite {amount}, Balance {Balance}");
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            //Console.WriteLine($"{Name}: Withdraw {amount}, Balance {Balance}");
            transaction.Invoke($"{Name}: Withdraw {amount}, Balance {Balance}");
            //TransactionHandlerEvent.Invoke($"{Name}: Withdraw {amount}, Balance {Balance}");
        }
    }
}
