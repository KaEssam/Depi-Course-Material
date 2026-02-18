using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal class Data<T> where T : class
    {
        public List<T> items { get; set; } = new();
        public void Add(T item)
        {
            items.Add(item);
        }
    }
}
