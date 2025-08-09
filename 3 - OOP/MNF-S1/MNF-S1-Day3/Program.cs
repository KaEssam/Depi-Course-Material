namespace MNF_S1_Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //Animal animal = new Animal();
            //animal.makeSound();

            //Dog dog = new Dog();
            //dog.makeSound();


            Cat cat = new Cat();



            //Animal[] animals = { new Animal(), new Dog(), new Cat() };

            //foreach(Animal animal in animals)
            //{
            //    animal.makeSound();
            //    animal.eat();
            //}

            //Book book = new Book();
            //book.Title = "c#";

            //book.displayINfo();

            //Console.WriteLine(book.ItemId);

            //Book book1 = new Book("c#","Ahemd");
            //book1.displayINfo();

            Book book2 = new Book("c#","ahmed");

            Console.WriteLine(book2.ToString());


        }



    }


    // parant(base) class 
    //class Animal
    //{
    //  public string Name { get; set; }
    //  public virtual void makeSound()
    //    {
    //        Console.WriteLine("animal sound");
    //    }

    //    public void eat()
    //    {
    //        Console.WriteLine("animal eat");
    //    }
    //}

    //// child(drived class)  
    //class Dog : Animal
    //{
    //    public override void makeSound()
    //    {
    //        Console.WriteLine("dog sound");
    //    }

    //    public new void eat()
    //    {
    //        Console.WriteLine("dog eat");
    //    }
    //}

    class Cat 
    {
        private Cat()
        {
            
        }


        public new void eat()
        {
            Console.WriteLine("cat eat");
        }
    }


}
