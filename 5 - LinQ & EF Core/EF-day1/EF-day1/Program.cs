namespace EF_day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplictionDbContext();

            var emp = new Employee();
           

            context.Employees.Add(emp);
            context.SaveChanges();
        }
    }
}
