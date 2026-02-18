namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Animal animal = new Animal();
            Animal Dog = new Dog(); //
            //Dog dog = new Dog();
            //Dog cat = new Cat();
            //Dog dog1 = new Animal();

            //Dog.Name = "ddad";
            //dog.Name = "sadada";
            //Dog.Name = "";
           //Dog.id=
            Dog.Sound(); //
            //dog.Sound(); //
            //cat.Sound();
        }
    }


    public class Animal // 1
    {
        public string Name { get; set; }

        public void Sound()
        {
            Console.WriteLine("Animal Sound");
        }

        public Animal()
        {
            Console.WriteLine("Animal Ctor");
        }

        public Animal(string name): this()
        {
            Name = name;
        }
    }

    public class Dog : Animal //3
    {
        public int id { get; set; }
        public int count { get; set; }
        public new void Sound()
        {
            Console.WriteLine("Dog Sound");
        }

        public Dog()
        {
            Console.WriteLine("Dog Ctor");
        }

        public Dog(string name,int count,Dog dog):base(name)
        {
           this.count = count;
        }
    }

    public class Cat : Dog
    {
        public  void Sound()
        {
            Console.WriteLine("Cat Sound");
        }
    }
}
