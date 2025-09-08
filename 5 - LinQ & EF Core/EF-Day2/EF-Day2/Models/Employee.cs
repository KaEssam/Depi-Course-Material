using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Day2.Models
{
    //[NotMapped]
    class Employee
    {
        [Key]
        public int ssn { get; set; }
        public string  FirstName { get; set; }

        public string  LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Precision(10,2)]
        public decimal Salary { get; set; }

        //[NotMapped]
        public DateTime CreatedAt { get; set; }

        //work (1:M)
        public int DepartmentId { get; set; }
        public Department department { get; set; }


        public int? SuperId { get; set; }
        public Employee? Super { get; set; }

        public ICollection<Employee> emps { get; set; }
    }
}
