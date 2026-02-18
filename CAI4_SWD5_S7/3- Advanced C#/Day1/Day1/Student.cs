using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal class Student
    {
        private string[] names = { "nada", "ali", "noor", "mariam" };

        //public string  Names{ get { return names[value]; } set; }

        //student[name]   ,, student[name]= "mido"
        public string this[int x]
        { 
            get { return names[x]; }
            set { names[x] = value; }
        }


        //student["noor"] => id: 2

        public int this[string name] 
        {
            get
            {
                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] == name)
                    {
                        return i;
                    }
                };
                return -1;
            }
            set
            {
                 names[value] = name;
            }
        }

        public string getName(int index)
        {
            return names[index]; 
        }

        public void setName(int id,string name)
        {
            names[id] = name;
        }
    }
}
