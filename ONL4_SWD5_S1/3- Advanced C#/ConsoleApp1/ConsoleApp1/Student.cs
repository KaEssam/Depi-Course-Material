using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace ConsoleApp1
{
    internal class Student
    {
        private string[] students = { "moaz", "ali", "negm" };

        private Dictionary<string,string> data = new Dictionary<string,string>();
        public int num { get; set; }
        //indexer
        public string this[int index] 
        {
            get { return students[index]; }
            set{ students[index] = value; }
        }

        public string this[string name]
        {
            get { return data.ContainsKey(name) ? data[name] : "Not Found"; }
            set { data[name] = value; }
        }

        //public string GetStudnt(int id)
        //{
        //    return students[id]; 
        //}

        //public void SetStudent(int i,string student)
        //{
        //    students[i] = student;
        //}
    }
}
