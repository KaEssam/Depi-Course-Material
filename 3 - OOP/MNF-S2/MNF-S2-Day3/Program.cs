using MNF_S2;

namespace MNF_S2_Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Book book = new Book(1, "c#", 20, true);

            //Animal animal = new Animal();
            //animal.makeSound();
            //Dog dog = new Dog();
            //dog.makeSound();
            //Cat cat = new Cat();
            //cat.makeSound();


            //Animal[] animals = { new Animal(), new Dog(), new Cat() };

            //foreach(Animal a in animals)
            //{
            //    a.makeSound();
            //}

            EBook eBook = new EBook();
            eBook.Author = "Ahmed";
            eBook.Price = 100;
            eBook.Title = "c#";
            eBook.Category = "coding";

            //eBook.DisplyInfo();

            Console.WriteLine(eBook.ToString());

            //PUBLIC - PRIVATE- PROTECTED- INTERNAL- INTERNAL PROTECTED


        }
    }

    // parant(base) class
   // public class Animal
   // {
   //     public string Name { get; set; }
   //     public virtual void makeSound() { Console.WriteLine("animal sound"); }
   // }



   // // child(drived) class
   //public class Dog :Animal
   // {
   //     public virtual new void makeSound() { Console.WriteLine("dog sound"); }
   // }

   // public class Cat :Dog
   // {
   //     //method hiding
   //     public override void makeSound() { Console.WriteLine("cat sound"); }
   // }

 

}
