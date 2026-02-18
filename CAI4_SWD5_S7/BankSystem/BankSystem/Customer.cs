using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal class Customer
    {
        public string NationalId { get; set; }
        public string CustomerName { get; set; }

      public  List<Account> accounts { get; set; } = new();
    }
}
