using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class AuditService<T> where T : IAudit
    {
        public void printT(T obj)
        {
            Console.WriteLine(obj.createAt);
        }
    }
}
