using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal class Bank
    {
        private readonly Data<Customer> _customers = new();
        //List<Customer> customers { get; set; } = new();

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }


        public void AddAccount(Customer customer, Account account)
        {
            customer.accounts.Add(account);
        }


    }
}
