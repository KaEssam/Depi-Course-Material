using QAL_S1;

namespace QAL_S1_Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Animal animal = new Animal();
            //animal.MakeSound();

            //Dog dog = new Dog();
            //dog.MakeSound();

            //Cat cat = new Cat();
            //cat.MakeSound();

            //Animal[] animals = { new Dog(), new Cat(), new Animal()};

            //foreach(Animal a in animals)
            //{
            //    a.MakeSound();
            //}

            //LibraryItem item = new LibraryItem();
            //LibraryItem item1 = new LibraryItem();
            //LibraryItem item3 = new LibraryItem();
            //LibraryItem item4 = new LibraryItem();
            //LibraryItem item5 = new LibraryItem();

            //EBook eBook = new EBook();
            LibraryItem eBook1 = new EBook("c#","coding","ali");

            EBook eBook = new EBook();
            Console.WriteLine(eBook1.ToString());
            //eBook1.DisplyInfo();

        }
    }

    ////base class (parant) super class
    //class Animal
    //{
    //  public string Name { get; set; }
    //  public virtual  void MakeSound() { Console.WriteLine("Animal Sound"); }
    //}


    //// drived class(child) subclass
    //class Dog : Animal
    //{
    //   public override void MakeSound() { Console.WriteLine("Dog Sound"); }
    //}

    //class Cat :Dog
    //{
    //    ////method hiding => base class
    //    public new void MakeSound() { Console.WriteLine("Cat Sound"); }
    //}
}
