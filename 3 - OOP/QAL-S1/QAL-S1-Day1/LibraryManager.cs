
public class LibraryManager
{
    private List<string> bookTitles = new List<string>();
    private string[] bookAuthors = new string[100];
    private string[] bookISBNs = new string[100];
    private int[] bookCopies = new int[100];
    private int bookCount = 0;

    
    private string[] userNames = new string[50];
    private string[] userEmails = new string[50];
    private int[] userIDs = new int[50];
    private int[] userBorrowedBooks = new int[50];
    private int userCount = 0;


    public void AddBook(string title, string author, string isbn, int copies)
    {
        bookTitles[bookCount] = title;
        bookAuthors[bookCount] = author;
        bookISBNs[bookCount] = isbn;
        bookCopies[bookCount] = copies;
        bookCount++;

    }

    public void AddUser(string name, string email, int userId)
    {
        userNames[userCount] = name;
        userEmails[userCount] = email;
        userIDs[userCount] = userId;
        userBorrowedBooks[userCount] = 0;
        userCount++;
    }

    public void DisplayBook(int index)
    {

        if (index >= 0 && index < bookCount)
        {
            Console.WriteLine($"Title: {bookTitles[index]}");
            Console.WriteLine($"Author: {bookAuthors[index]}");
            Console.WriteLine($"ISBN: {bookISBNs[index]}");
            Console.WriteLine($"Copies: {bookCopies[index]}");
            Console.WriteLine("------------------------");
        }
        else
        {
            Console.WriteLine("Invalid book index!");
        }
    }

    public void DisplayUser(int index)
    {
        if (index >= 0 && index < userCount)
        {
            Console.WriteLine($"Name: {userNames[index]}");
            Console.WriteLine($"Email: {userEmails[index]}");
            Console.WriteLine($"User ID: {userIDs[index]}");
            Console.WriteLine($"Borrowed Books: {userBorrowedBooks[index]}");
            Console.WriteLine("------------------------");
        }
        else
        {
            Console.WriteLine("Invalid user index!");
        }
    }

    public void BorrowBook(int userIndex, int bookIndex)
    {

        if (bookIndex >= 0 && bookIndex < bookCount &&
            userIndex >= 0 && userIndex < userCount &&
            bookCopies[bookIndex] > 0 &&
            userBorrowedBooks[userIndex] < 3)
        {
            bookCopies[bookIndex]--;
            userBorrowedBooks[userIndex]++;

            Console.WriteLine($"{userNames[userIndex]} borrowed {bookTitles[bookIndex]}");
        }
        else
        {
            Console.WriteLine("Cannot borrow book!");
        }
    }

    public void ReturnBook(int userIndex, int bookIndex)
    {
        if (bookIndex >= 0 && bookIndex < bookCount &&
            userIndex >= 0 && userIndex < userCount &&
            userBorrowedBooks[userIndex] > 0)
        {
            bookCopies[bookIndex]++;
            userBorrowedBooks[userIndex]--;
            Console.WriteLine($"{userNames[userIndex]} returned {bookTitles[bookIndex]}");
        }
        else
        {
            Console.WriteLine("Cannot return book!");
        }
    }

    public void ShowAllBooks()
    {
        Console.WriteLine("=== All Books ===");
        for (int i = 0; i < bookCount; i++)
        {
            DisplayBook(i);
        }
    }

    public void ShowAllUsers()
    {
        Console.WriteLine("=== All Users ===");
        for (int i = 0; i < userCount; i++)
        {
            DisplayUser(i);
        }
    }

    public void CorruptData()
    {
        Console.WriteLine("\n=== Demonstrating Data Corruption ===");
        if (bookCount > 0)
        {
            bookCopies[0] = -100;
        }
        if (userCount > 0)
        {
            userBorrowedBooks[0] = 999;
        }
        Console.WriteLine("Data has been corrupted!");
    }

    public void ShowProblems()
    {
        Console.WriteLine("\n=== WHAT WENT WRONG? ===");
        Console.WriteLine("❌ Data scattered across multiple arrays");
        Console.WriteLine("❌ No validation - garbage data accepted");
        Console.WriteLine("❌ Easy to corrupt data accidentally");
        Console.WriteLine("❌ Hard to maintain - arrays must stay in sync");
        Console.WriteLine("❌ Difficult to extend - need new arrays for each type");
        Console.WriteLine("❌ Error-prone - easy to use wrong array index");
        Console.WriteLine("❌ No real-world modeling - doesn't match how we think");
    }

    public void ShowSolution()
    {
        Console.WriteLine("\n=== THE SOLUTION: OBJECT-ORIENTED PROGRAMMING! ===");
        Console.WriteLine("✅ Group related data and behavior together");
        Console.WriteLine("✅ Validate data to prevent corruption");
        Console.WriteLine("✅ Model real-world entities (Books, Users)");
        Console.WriteLine("✅ Easy to extend and maintain");
        Console.WriteLine("✅ Encapsulation protects data integrity");
        Console.WriteLine("✅ Code that matches how we think about the world");
    }
}
