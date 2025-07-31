namespace MNF_S1_Day1;

public class Book
{
    // fields => DATA STORAGE
    private string _title;
    private string _author;
    private int _isbn;
    private int _copies;

    // public Book(int isbn, string title, string author, int copies)
    // {
    //     Title = title;
    //     Author = author;
    //     Isbn = isbn;
    //     Copies = copies;
    // }
    // properties => DATA VALIDATION
    public string Title {
        get
        {
            return _title;
        }
        set
        {
            if (string.IsNullOrEmpty(value.Trim()))
            {
                Console.WriteLine("Title cannot be null");
            }
            else
            {
                _title = value;
            }
            // if (string.IsNullOrWhiteSpace(value))
            //    throw new Exception("Title cannot be null or whitespace");
            

        }
        
    }
    
    public string Author {
        get
        {
            return _author;
        }
        set
        {
            // if(string.IsNullOrEmpty(value.Trim()))
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Author cannot be null or whitespace");
            }
            _author = value;
        }
        
        
    }

    // public int Isbn
    // {
    //     get
    //     {
    //         return _isbn;
    //     }
    //     set
    //     {
    //         if (value < 10)
    //             Console.WriteLine("Isbn cannot be less than 10");
    //         _isbn = value;
    //     }
    // }

    // public int Isbn
    // {
    //     get
    //     {
    //         return _isbn;
    //     }
    //     set
    //     {
    //         _isbn = value;
    //     }
    // }

    public int Isbn { get; private set; }

    public int setIsbn(int isbn)
    {
        return Isbn = isbn;
    }

    public int  Copies {
        get
        {
            return _copies;
        }
        set
        {
            if (value < 1)
                Console.WriteLine("Copies cannot be less than 1");
            _copies = value;
        }}


    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"ISBN: {Isbn}");
        Console.WriteLine($"Copies: {Copies}");
        Console.WriteLine("-------------------------");
    }

    public bool IsAvailable()
    {
        return Copies > 0;
    }
    
}