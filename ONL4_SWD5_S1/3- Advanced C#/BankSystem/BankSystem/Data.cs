using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    internal class Data<T> where T : class
    {
        private readonly List<T> _data = new();
        public void Add(T data) => _data.Add(data);
        public bool Remove(T data) => _data.Remove(data);

        public int Count => _data.Count;

        public List<T> GetData() => new(_data);

        public T? Find(Func<T, bool>predicate ) => _data.FirstOrDefault(predicate);


    }
}
