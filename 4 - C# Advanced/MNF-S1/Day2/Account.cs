using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Account
    {
        public delegate void TrancHandler(string msg);


        //event
        public event TrancHandler TrancHandlerEvent;


        public string Name { get; set; }
        public decimal Balance { get; set; }

        public TrancHandler trancHandler;


        public void Deposit(decimal amount)
        {
            Balance += amount;
            //Console.WriteLine($"{Name}: Deposite {amount}, new Balance {Balance}");
            //trancHandler.Invoke($"{Name}: Deposite {amount}, Balance {Balance}");
            TrancHandlerEvent.Invoke($"{Name}: Deposite {amount}, Balance {Balance}");
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            //Console.WriteLine($"{Name}: withdraw {amount}, new Balance {Balance}");
            //trancHandler.Invoke($"{Name}: withdraw {amount}, Balance {Balance}");
            TrancHandlerEvent.Invoke($"{Name}: withdraw {amount}, Balance {Balance}");

        }
    }
}
