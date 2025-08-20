using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "defualt";
        public decimal Salary { get; set; }
        public string Role { get; set; }
        public string? Address { get; set; }


        public object this[int index]
        {

            get => index switch
            {
                0 => Id,
                1 => Name,
                2 => Salary,
                3 => Role,
                _ => "invlid index"
            };

            //get
            //{
            //    switch (index)
            //    {
            //        case 0: return Id;
            //        case 1: return Name;
            //        case 4: return Salary;
            //        case 3: return Role;
            //        default: return "invalid Index";
            //    }
            //}

            set
            {
                switch (index)
                {
                    case 0: Id = (int)value; break;
                    case 1: Name = (string)value; break;
                    case 4: Salary =(decimal) value; break;
                    case 3: Role = (string) value; break;
                }
            }
        }

        public object this[string index]
        {
            get
            {
                switch (index.ToLower())
                {
                    case "id": return Id;
                    case "name": return Name;
                    case "salary": return Salary;
                    case "role": return Role;
                    default: return "invalid Index";
                }
            }

            set
            {
                switch (index.ToLower())
                {
                    case "id": Id = (int)value; break;
                    case "name": Name = (string)value; break;
                    case "salary": Salary = (decimal)value; break;
                    case "role": Role = (string)value; break;
                }
            }
        }
    }
}
