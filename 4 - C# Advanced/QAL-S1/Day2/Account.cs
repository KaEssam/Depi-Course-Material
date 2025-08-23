using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Account
    {

        //public delegate void TransactionDelegate(string msg);

        //public event TransactionDelegate TransactionDelegateEvent;
        public string Name { get; set; }
        public decimal Balance { get; set; }

        //public TransactionDelegate transaction;

        // event (publisher)
        public event Action<string> onTransaction;

        public void Deposit(decimal amount)
        {
            Balance += amount;
            //Console.WriteLine($"{Name}: Depoist {amount}, Balance {Balance}");

            //Program.SendSms($"{Name}: Depoist {amount}, Balance {Balance}");

            //transaction.Invoke($"{Name}: Depoist {amount}, Balance {Balance}");
            //TransactionDelegateEvent.Invoke($"{Name}: Depoist {amount}, Balance {Balance}");
            onTransaction.Invoke($"{Name}: Depoist {amount}, Balance {Balance}");
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            //Console.WriteLine($"{Name}: Withdraw {amount}, Balance {Balance}");

            //transaction.Invoke($"{Name}: Withdraw {amount}, Balance {Balance}");
            //TransactionDelegateEvent.Invoke($"{Name}: Withdraw {amount}, Balance {Balance}");
            onTransaction.Invoke($"{Name}: Withdraw {amount}, Balance {Balance}");

        }
    }
}
