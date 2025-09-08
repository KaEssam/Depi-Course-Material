using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Day2.Models
{
    class Department
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        //[ForeignKey("ManagerId")]
        public int EmployeeId { get; set; }
        public Employee? Manager { get; set; }


        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
