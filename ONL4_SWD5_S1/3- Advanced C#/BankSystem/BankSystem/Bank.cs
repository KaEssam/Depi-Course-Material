using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal class Bank
    {
        public string Name { get;}
        public  string BranchCode { get; set; }

        private readonly Data<Customer> _customer = new();

        public Bank(string name, string code)
        {
            Name = name;
            BranchCode = code;
        }

        public Customer AddCustomer(string name, string naId)
        {
            Customer customer = new Customer(name, naId);
            _customer.Add(customer);
            return customer;

        }

        public CurrantAccount OpenCurrantAccount(Customer customer, decimal overdraft)
        {
            var account = new CurrantAccount(overdraft);
            customer.accounts.Add(account);
            return account;
        }

        public bool Transfar(Account To, Account from, decimal amount)
        {
            if(amount <= 0)
                return false;

            if(!from.Withdraw(amount))
                return false;

            To.Deposit(amount);
            return true;

        }

    }
}
