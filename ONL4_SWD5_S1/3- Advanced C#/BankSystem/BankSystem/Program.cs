using System.Collections.Generic;

namespace BankSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //Func<List<Account>,decimal> sum = (accounts) =>
            //{
            //    decimal sum = 0;
            //    foreach (var account in accounts)
            //    {
            //        sum += account.Balance;
            //    }
            //    return sum;
            //};

            //List<CurrantAccount> accounts = new List<CurrantAccount>()
            //{
            //    new CurrantAccount(){Balance = 2000},
            //    new CurrantAccount(){Balance = 5000},
            //    new CurrantAccount(){Balance = 10000},

            //};
            //Func<List<CurrantAccount>, decimal> sum = (accounts) => accounts.Sum(account => account.Balance);

            //Console.WriteLine(sum);

            var bank = new Bank("NBA", "NBA-32323");

            var karim = bank.AddCustomer("Karim", "578572");
            Console.WriteLine($"{karim}");
            var ali = bank.AddCustomer("Ali", "57857dada2");
            var nada = bank.AddCustomer("Nada", "57dada8572");

            var karimAccount = bank.OpenCurrantAccount(karim, 5000);
            var nadaAccount = bank.OpenCurrantAccount(nada, 500);

            TranscationHandler transcation = msg => Console.WriteLine($"sms: {msg}");
            karimAccount.onTranscationComplete += transcation;
            nadaAccount.onTranscationComplete += transcation;


            karimAccount.Deposit(5000);
            nadaAccount.Deposit(50000);

            karimAccount.GetReport();

            nadaAccount.Withdraw(1000);


            bank.Transfar(karimAccount, nadaAccount, 200);
        }

        //public static decimal sum1(List<Account> accounts)
        //{
        //    decimal sum = 0;
        //    foreach (var account in accounts)
        //    {
        //        sum += account.Balance;
        //    }
        //    return sum;
        //}
    }
}
