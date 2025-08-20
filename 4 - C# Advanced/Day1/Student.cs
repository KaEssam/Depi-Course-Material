using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
   public class Student
    {

        public int Id { get; set; }
        public int age { get; set; }

        public string address { get; set; }

        public DateTime? graduateDate { get; set; }

        private string[] students = new string[5];

        public string this[int index]
        {
            get { return students[index]; }
            set { students[index] = value; }
        }

        //public string[] Students { get { return students;  } set { students = value; } }


        public bool isGraduated { get { return !graduateDate.HasValue; } }

        // emp is null ?


    }
}
