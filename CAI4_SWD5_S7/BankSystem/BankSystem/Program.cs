namespace BankSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // type (deposit- withdraw- trnsfar) - data - amount - desc 
            // deposti

            Customer customer1= new Customer()
            {
                CustomerName = "test",
            };

            Bank bank = new Bank();
            Bank bank1 = new Bank();

            //bank -> test1 - test2 
            //
            bank.AddCustomer(customer1);
            bank1.AddCustomer(customer1);
        }
    }
}
