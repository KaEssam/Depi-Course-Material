using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public delegate void TranscationHandler(string msg);
    internal abstract class Account
    {
        public static int _newNum = 1000;
        public int AccountNumber { get;}
        public decimal Balance { get;  set; }
        public DateTime DateOpened { get; }


        public TranscationHandler onTranscationComplete;
        public List<Transction> transctions { get; set; } = new();

        protected Account()
        {
            AccountNumber = _newNum++;
            DateOpened = DateTime.Now;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if(amount <= 0)
                Console.WriteLine("Amount must Be Postivie");

            Balance += amount;

            //TODO: 1- ADD TO TRANSACTION HISTORY
            AddTranscation(TranscationType.Deposit, amount,$"Deposited {amount} EGP to #{AccountNumber}");
            //TODO: 2- NOTIFACATION
            //sendEmail($"withdraw {amount} EGP from #{AccountNumber}");
            onTranscationComplete($"Deposited {amount} EGP to #{AccountNumber}");
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (Balance <= 0)
                return false;

            if(amount > Balance)
                return false;

            Balance -= amount;
            //TODO: 1- ADD TO TRANSACTION HISTORY
            AddTranscation(TranscationType.Withdraw, amount, $"withdraw {amount} EGP from #{AccountNumber}");
            //TODO: 2- NOTIFACATION
            onTranscationComplete($"withdraw {amount} EGP from #{AccountNumber}");
            return true;
        }


        public abstract decimal CalculateMonthlyInterset();
        public abstract string AccountType();

        protected void AddTranscation(TranscationType transcationType,decimal amount, string desc)
        {
            transctions.Add(new Transction
            {
                Type = transcationType,
                Amount = amount,
                date = DateTime.Now,
                Descripton = desc,
            });
        }

        public void sendEmail(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}
