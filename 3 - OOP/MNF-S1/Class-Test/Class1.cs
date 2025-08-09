using MNF_S1_Day3;

namespace Class_Test
{
    public class Class1 : LibraryItem
    {
       protected override void displayINfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Id: {_itemId}");
            Console.WriteLine($"Added in: {DateAdd}");
        }
    }
}
