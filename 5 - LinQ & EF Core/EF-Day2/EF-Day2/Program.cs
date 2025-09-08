using EF_Day2.Data;
using EF_Day2.Models;
using System.ComponentModel.DataAnnotations;

namespace EF_Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //it

            var context = new ApplicationDbContext();

            //var aya7aga = new Project() { Name = "i"};
            //context.Add(aya7aga);

            //context.SaveChanges();


            var emp1 = new Employee() { FirstName = "karim", LastName = "essam",Salary=10000 };
            context.Add(emp1);
            context.SaveChanges();
            var emp2 = new Employee() { FirstName = "marim", LastName = "ali",Salary=10000,SuperId=1 };
            context.Add(emp2);
            context.SaveChanges();
            var dept = new Department() { Name = "cs", EmployeeId = emp1.ssn,Address="dadad" };
            context.Add(dept);
            context.SaveChanges();

            emp1.department = dept;
            emp2.department = dept;
            context.Add(emp1);
            context.Add(emp2);
            context.SaveChanges();
            var proj = new Project() { Name = "ERP" };

            context.Add(proj);
            context.SaveChanges();




        }
    }
}
