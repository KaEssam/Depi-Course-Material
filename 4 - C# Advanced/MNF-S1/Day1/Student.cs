using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Student
    {
        public  int Id { get; set; }
        public string Name { get; set; } = "";
        public double GPA { get; set; }


        public object this[int index]
        {
            get => index switch
            {
                1 => this.Id,
                2 => this.GPA,
                3 => this.Name,
                _ => "error",
            };
            set
            {
                switch (index)
                {
                    case 1: Id = (int)value; break;
                    case 2: GPA = (double)value;break;
                    case 3: Name = (string)value; break;
                }
            }
        }

        public object this[string propName]
        {
            get
            {
                switch (propName.ToLower())
                {
                    case "id": return this.Id;
                    case "gpa": return this.GPA;
                    case "name": return this.Name;
                    default: return "error";
                }
                    
            }
            set
            {
                switch (propName.ToLower())
                {
                    case "id": Id = (int)value; break;
                    case "gpa": GPA = (double)value; break;
                    case "name": Name = (string)value; break;
                }
            }
        }
    }
}
