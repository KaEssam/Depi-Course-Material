

namespace Day1
{
    class Box<T> where T : class
    {
        public T Value { get; set; }

        void print (T value)
        {
            Console.WriteLine(value);
        }

    }
}
