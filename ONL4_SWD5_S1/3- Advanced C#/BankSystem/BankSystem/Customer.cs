using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal class Customer
    {
        private static int _nextId = 1;
        public int Id { get;}
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public List<Account> accounts { get; set; } = new();

        public Customer(string name, string ssn)
        {
            Id = _nextId++;
            FullName = name;
            NationalId = ssn;
        }


        public override string ToString()
        {
            return $"{FullName}";
        }

        public decimal TotalBalacne => accounts.Sum(a => a.Balance);

        //private decimal sum(List<Account> accounts)
        //{
        //    decimal sum = 0;
        //    foreach(var account in accounts)
        //    {
        //        sum += account.Balance;
        //    }
        //    return sum;
        //}
    }
}
