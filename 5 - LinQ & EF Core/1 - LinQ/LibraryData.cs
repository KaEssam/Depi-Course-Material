using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    // Entity Classes
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime JoinedDate { get; set; }
        public string MembershipType { get; set; } // Standard, Premium
        public string Email { get; set; }
    }

    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
    }

    // Dataset Provider
    public static class LibraryData
    {
        public static List<Book> Books { get; private set; }
        public static List<Author> Authors { get; private set; }
        public static List<Member> Members { get; private set; }
        public static List<Loan> Loans { get; private set; }

        static LibraryData()
        {
            InitializeData();
        }

        private static void InitializeData()
        {
            // Initialize Authors
            Authors = new List<Author>
            {
                new Author { Id = 1, Name = "Robert C. Martin", Country = "USA", BirthDate = new DateTime(1952, 12, 5) },
                new Author { Id = 2, Name = "Martin Fowler", Country = "UK", BirthDate = new DateTime(1963, 12, 18) },
                new Author { Id = 3, Name = "Eric Evans", Country = "USA", BirthDate = new DateTime(1965, 3, 15) },
                new Author { Id = 4, Name = "Yuval Noah Harari", Country = "UEA", BirthDate = new DateTime(1976, 2, 24) },
                new Author { Id = 5, Name = "Stephen Hawking", Country = "UK", BirthDate = new DateTime(1942, 1, 8) },
                new Author { Id = 6, Name = "J.K. Rowling", Country = "UK", BirthDate = new DateTime(1965, 7, 31) },
                new Author { Id = 7, Name = "George R.R. Martin", Country = "USA", BirthDate = new DateTime(1948, 9, 20) },
                new Author { Id = 8, Name = "Walter Isaacson", Country = "USA", BirthDate = new DateTime(1952, 5, 20) },
                new Author { Id = 9, Name = "Dale Carnegie", Country = "USA", BirthDate = new DateTime(1888, 11, 24) },
                new Author { Id = 10, Name = "Simon Sinek", Country = "UK", BirthDate = new DateTime(1973, 10, 9) },
                new Author { Id = 11, Name = "Daniel Kahneman", Country = "UEA", BirthDate = new DateTime(1934, 3, 5) },
                new Author { Id = 12, Name = "Malcolm Gladwell", Country = "Canada", BirthDate = new DateTime(1963, 9, 3) },
                new Author { Id = 13, Name = "Angela Duckworth", Country = "USA", BirthDate = new DateTime(1970, 7, 19) },
                new Author { Id = 14, Name = "Cal Newport", Country = "USA", BirthDate = new DateTime(1982, 6, 23) },
                new Author { Id = 15, Name = "James Clear", Country = "USA", BirthDate = new DateTime(1986, 1, 22) },
                new Author { Id = 16, Name = "Brené Brown", Country = "USA", BirthDate = new DateTime(1965, 11, 18) },
                new Author { Id = 17, Name = "Adam Grant", Country = "USA", BirthDate = new DateTime(1981, 8, 13) },
                new Author { Id = 18, Name = "Susan Cain", Country = "USA", BirthDate = new DateTime(1968, 3, 13) },
                new Author { Id = 19, Name = "Charles Duhigg", Country = "USA", BirthDate = new DateTime(1974, 6, 20) },
                new Author { Id = 20, Name = "Atul Gawande", Country = "USA", BirthDate = new DateTime(1965, 11, 5) }
            };

            // Initialize Books
            Books = new List<Book>
            {
                // Programming Books
                new Book { Id = 1, Title = "Clean Code", Genre = "Programming", AuthorId = 1, PublishedYear = 2008, IsAvailable = true, Price = 45.99m },
                new Book { Id = 2, Title = "Clean Architecture", Genre = "Programming", AuthorId = 1, PublishedYear = 2017, IsAvailable = false, Price = 49.99m },
                new Book { Id = 3, Title = "Refactoring", Genre = "Programming", AuthorId = 2, PublishedYear = 1999, IsAvailable = true, Price = 39.99m },
                new Book { Id = 4, Title = "Patterns of Enterprise Application Architecture", Genre = "Programming", AuthorId = 2, PublishedYear = 2002, IsAvailable = true, Price = 54.99m },
                new Book { Id = 5, Title = "Domain-Driven Design", Genre = "Programming", AuthorId = 3, PublishedYear = 2003, IsAvailable = false, Price = 44.99m },

                // History Books
                new Book { Id = 6, Title = "Sapiens", Genre = "History", AuthorId = 4, PublishedYear = 2011, IsAvailable = true, Price = 24.99m },
                new Book { Id = 7, Title = "Homo Deus", Genre = "History", AuthorId = 4, PublishedYear = 2015, IsAvailable = true, Price = 26.99m },
                new Book { Id = 8, Title = "21 Lessons for the 21st Century", Genre = "History", AuthorId = 4, PublishedYear = 2018, IsAvailable = false, Price = 28.99m },

                // Science Books
                new Book { Id = 9, Title = "A Brief History of Time", Genre = "Science", AuthorId = 5, PublishedYear = 1988, IsAvailable = true, Price = 19.99m },
                new Book { Id = 10, Title = "The Universe in a Nutshell", Genre = "Science", AuthorId = 5, PublishedYear = 2001, IsAvailable = true, Price = 22.99m },

                // Fiction Books
                new Book { Id = 11, Title = "Harry Potter and the Philosopher's Stone", Genre = "Fiction", AuthorId = 6, PublishedYear = 1997, IsAvailable = false, Price = 15.99m },
                new Book { Id = 12, Title = "Harry Potter and the Chamber of Secrets", Genre = "Fiction", AuthorId = 6, PublishedYear = 1998, IsAvailable = true, Price = 15.99m },
                new Book { Id = 13, Title = "A Game of Thrones", Genre = "Fiction", AuthorId = 7, PublishedYear = 1996, IsAvailable = true, Price = 18.99m },
                new Book { Id = 14, Title = "A Clash of Kings", Genre = "Fiction", AuthorId = 7, PublishedYear = 1998, IsAvailable = false, Price = 18.99m },

                // Biography Books
                new Book { Id = 15, Title = "Steve Jobs", Genre = "Biography", AuthorId = 8, PublishedYear = 2011, IsAvailable = true, Price = 29.99m },
                new Book { Id = 16, Title = "Leonardo da Vinci", Genre = "Biography", AuthorId = 8, PublishedYear = 2017, IsAvailable = true, Price = 32.99m },
                new Book { Id = 17, Title = "How to Win Friends and Influence People", Genre = "Biography", AuthorId = 9, PublishedYear = 1936, IsAvailable = false, Price = 12.99m },

                // Self-Help Books
                new Book { Id = 18, Title = "Start With Why", Genre = "Self-Help", AuthorId = 10, PublishedYear = 2009, IsAvailable = true, Price = 21.99m },
                new Book { Id = 19, Title = "Thinking, Fast and Slow", Genre = "Self-Help", AuthorId = 11, PublishedYear = 2011, IsAvailable = true, Price = 25.99m },
                new Book { Id = 20, Title = "Outliers", Genre = "Self-Help", AuthorId = 12, PublishedYear = 2008, IsAvailable = false, Price = 23.99m },
                new Book { Id = 21, Title = "Grit", Genre = "Self-Help", AuthorId = 13, PublishedYear = 2016, IsAvailable = true, Price = 24.99m },
                new Book { Id = 22, Title = "Deep Work", Genre = "Self-Help", AuthorId = 14, PublishedYear = 2016, IsAvailable = true, Price = 26.99m },
                new Book { Id = 23, Title = "Atomic Habits", Genre = "Self-Help", AuthorId = 15, PublishedYear = 2018, IsAvailable = false, Price = 23.99m },
                new Book { Id = 24, Title = "Daring Greatly", Genre = "Self-Help", AuthorId = 16, PublishedYear = 2012, IsAvailable = true, Price = 22.99m },
                new Book { Id = 25, Title = "Give and Take", Genre = "Self-Help", AuthorId = 17, PublishedYear = 2013, IsAvailable = true, Price = 24.99m },
                new Book { Id = 26, Title = "Quiet", Genre = "Self-Help", AuthorId = 18, PublishedYear = 2012, IsAvailable = false, Price = 21.99m },
                new Book { Id = 27, Title = "The Power of Habit", Genre = "Self-Help", AuthorId = 19, PublishedYear = 2012, IsAvailable = true, Price = 25.99m },
                new Book { Id = 28, Title = "The Checklist Manifesto", Genre = "Self-Help", AuthorId = 20, PublishedYear = 2009, IsAvailable = true, Price = 23.99m }
            };

            // Initialize Members
            Members = new List<Member>
            {
                new Member { Id = 1, FullName = "John Smith", JoinedDate = new DateTime(2020, 1, 15), MembershipType = "Premium", Email = "john.smith@email.com" },
                new Member { Id = 2, FullName = "Sarah Johnson", JoinedDate = new DateTime(2019, 3, 22), MembershipType = "Standard", Email = "sarah.j@email.com" },
                new Member { Id = 3, FullName = "Michael Brown", JoinedDate = new DateTime(2021, 6, 10), MembershipType = "Premium", Email = "michael.b@email.com" },
                new Member { Id = 4, FullName = "Emily Davis", JoinedDate = new DateTime(2018, 11, 5), MembershipType = "Standard", Email = "emily.d@email.com" },
                new Member { Id = 5, FullName = "David Wilson", JoinedDate = new DateTime(2020, 8, 12), MembershipType = "Premium", Email = "david.w@email.com" },
                new Member { Id = 6, FullName = "Lisa Anderson", JoinedDate = new DateTime(2019, 9, 18), MembershipType = "Standard", Email = "lisa.a@email.com" },
                new Member { Id = 7, FullName = "Robert Taylor", JoinedDate = new DateTime(2021, 2, 28), MembershipType = "Premium", Email = "robert.t@email.com" },
                new Member { Id = 8, FullName = "Jennifer Martinez", JoinedDate = new DateTime(2018, 7, 14), MembershipType = "Standard", Email = "jennifer.m@email.com" },
                new Member { Id = 9, FullName = "Christopher Garcia", JoinedDate = new DateTime(2020, 4, 3), MembershipType = "Premium", Email = "chris.g@email.com" },
                new Member { Id = 10, FullName = "Amanda Rodriguez", JoinedDate = new DateTime(2019, 12, 8), MembershipType = "Standard", Email = "amanda.r@email.com" },
                new Member { Id = 11, FullName = "James Lopez", JoinedDate = new DateTime(2021, 1, 20), MembershipType = "Premium", Email = "james.l@email.com" },
                new Member { Id = 12, FullName = "Michelle White", JoinedDate = new DateTime(2018, 5, 30), MembershipType = "Standard", Email = "michelle.w@email.com" },
                new Member { Id = 13, FullName = "Daniel Lee", JoinedDate = new DateTime(2020, 10, 17), MembershipType = "Premium", Email = "daniel.l@email.com" },
                new Member { Id = 14, FullName = "Jessica Hall", JoinedDate = new DateTime(2019, 2, 11), MembershipType = "Standard", Email = "jessica.h@email.com" },
                new Member { Id = 15, FullName = "Matthew Allen", JoinedDate = new DateTime(2021, 7, 25), MembershipType = "Premium", Email = "matthew.a@email.com" },
                new Member { Id = 16, FullName = "Nicole Young", JoinedDate = new DateTime(2018, 8, 9), MembershipType = "Standard", Email = "nicole.y@email.com" },
                new Member { Id = 17, FullName = "Andrew King", JoinedDate = new DateTime(2020, 3, 14), MembershipType = "Premium", Email = "andrew.k@email.com" },
                new Member { Id = 18, FullName = "Stephanie Wright", JoinedDate = new DateTime(2019, 11, 2), MembershipType = "Standard", Email = "stephanie.w@email.com" },
                new Member { Id = 19, FullName = "Kevin Scott", JoinedDate = new DateTime(2021, 4, 19), MembershipType = "Premium", Email = "kevin.s@email.com" },
                new Member { Id = 20, FullName = "Rachel Green", JoinedDate = new DateTime(2018, 12, 7), MembershipType = "Standard", Email = "rachel.g@email.com" },
                new Member { Id = 21, FullName = "Thomas Baker", JoinedDate = new DateTime(2020, 6, 23), MembershipType = "Premium", Email = "thomas.b@email.com" },
                new Member { Id = 22, FullName = "Lauren Adams", JoinedDate = new DateTime(2019, 4, 16), MembershipType = "Standard", Email = "lauren.a@email.com" },
                new Member { Id = 23, FullName = "Ryan Nelson", JoinedDate = new DateTime(2021, 9, 8), MembershipType = "Premium", Email = "ryan.n@email.com" },
                new Member { Id = 24, FullName = "Ashley Carter", JoinedDate = new DateTime(2018, 10, 12), MembershipType = "Standard", Email = "ashley.c@email.com" },
                new Member { Id = 25, FullName = "Brandon Mitchell", JoinedDate = new DateTime(2020, 5, 29), MembershipType = "Premium", Email = "brandon.m@email.com" },
                new Member { Id = 26, FullName = "Megan Perez", JoinedDate = new DateTime(2019, 7, 4), MembershipType = "Standard", Email = "megan.p@email.com" },
                new Member { Id = 27, FullName = "Justin Roberts", JoinedDate = new DateTime(2021, 3, 31), MembershipType = "Premium", Email = "justin.r@email.com" },
                new Member { Id = 28, FullName = "Hannah Turner", JoinedDate = new DateTime(2018, 6, 21), MembershipType = "Standard", Email = "hannah.t@email.com" },
                new Member { Id = 29, FullName = "Tyler Phillips", JoinedDate = new DateTime(2020, 11, 13), MembershipType = "Premium", Email = "tyler.p@email.com" },
                new Member { Id = 30, FullName = "Samantha Campbell", JoinedDate = new DateTime(2019, 1, 26), MembershipType = "Standard", Email = "samantha.c@email.com" }
            };

            // Initialize Loans
            Loans = new List<Loan>
            {
                // Active Loans (no ReturnDate)
                new Loan { Id = 1, BookId = 2, MemberId = 1, LoanDate = new DateTime(2024, 1, 15), DueDate = new DateTime(2024, 2, 15), ReturnDate = null },
                new Loan { Id = 2, BookId = 5, MemberId = 3, LoanDate = new DateTime(2024, 1, 20), DueDate = new DateTime(2024, 2, 20), ReturnDate = null },
                new Loan { Id = 3, BookId = 8, MemberId = 5, LoanDate = new DateTime(2024, 1, 10), DueDate = new DateTime(2024, 2, 10), ReturnDate = null },
                new Loan { Id = 4, BookId = 11, MemberId = 7, LoanDate = new DateTime(2024, 1, 5), DueDate = new DateTime(2024, 2, 5), ReturnDate = null },
                new Loan { Id = 5, BookId = 14, MemberId = 9, LoanDate = new DateTime(2024, 1, 12), DueDate = new DateTime(2024, 2, 12), ReturnDate = null },
                new Loan { Id = 6, BookId = 17, MemberId = 11, LoanDate = new DateTime(2024, 1, 8), DueDate = new DateTime(2024, 2, 8), ReturnDate = null },
                new Loan { Id = 7, BookId = 20, MemberId = 13, LoanDate = new DateTime(2024, 1, 18), DueDate = new DateTime(2024, 2, 18), ReturnDate = null },
                new Loan { Id = 8, BookId = 23, MemberId = 15, LoanDate = new DateTime(2024, 1, 3), DueDate = new DateTime(2024, 2, 3), ReturnDate = null },
                new Loan { Id = 9, BookId = 26, MemberId = 17, LoanDate = new DateTime(2024, 1, 25), DueDate = new DateTime(2024, 2, 25), ReturnDate = null },

                // Returned Loans
                new Loan { Id = 10, BookId = 1, MemberId = 2, LoanDate = new DateTime(2023, 12, 1), DueDate = new DateTime(2024, 1, 1), ReturnDate = new DateTime(2023, 12, 28) },
                new Loan { Id = 11, BookId = 3, MemberId = 4, LoanDate = new DateTime(2023, 11, 15), DueDate = new DateTime(2023, 12, 15), ReturnDate = new DateTime(2023, 12, 10) },
                new Loan { Id = 12, BookId = 6, MemberId = 6, LoanDate = new DateTime(2023, 10, 20), DueDate = new DateTime(2023, 11, 20), ReturnDate = new DateTime(2023, 11, 15) },
                new Loan { Id = 13, BookId = 9, MemberId = 8, LoanDate = new DateTime(2023, 9, 10), DueDate = new DateTime(2023, 10, 10), ReturnDate = new DateTime(2023, 10, 5) },
                new Loan { Id = 14, BookId = 12, MemberId = 10, LoanDate = new DateTime(2023, 8, 25), DueDate = new DateTime(2023, 9, 25), ReturnDate = new DateTime(2023, 9, 20) },
                new Loan { Id = 15, BookId = 15, MemberId = 12, LoanDate = new DateTime(2023, 7, 30), DueDate = new DateTime(2023, 8, 30), ReturnDate = new DateTime(2023, 8, 25) },
                new Loan { Id = 16, BookId = 18, MemberId = 14, LoanDate = new DateTime(2023, 6, 15), DueDate = new DateTime(2023, 7, 15), ReturnDate = new DateTime(2023, 7, 10) },
                new Loan { Id = 17, BookId = 21, MemberId = 16, LoanDate = new DateTime(2023, 5, 20), DueDate = new DateTime(2023, 6, 20), ReturnDate = new DateTime(2023, 6, 15) },
                new Loan { Id = 18, BookId = 24, MemberId = 18, LoanDate = new DateTime(2023, 4, 10), DueDate = new DateTime(2023, 5, 10), ReturnDate = new DateTime(2023, 5, 5) },
                new Loan { Id = 19, BookId = 27, MemberId = 20, LoanDate = new DateTime(2023, 3, 25), DueDate = new DateTime(2023, 4, 25), ReturnDate = new DateTime(2023, 4, 20) },
                new Loan { Id = 20, BookId = 4, MemberId = 22, LoanDate = new DateTime(2023, 2, 28), DueDate = new DateTime(2023, 3, 28), ReturnDate = new DateTime(2023, 3, 25) },
                new Loan { Id = 21, BookId = 7, MemberId = 24, LoanDate = new DateTime(2023, 1, 15), DueDate = new DateTime(2023, 2, 15), ReturnDate = new DateTime(2023, 2, 10) },
                new Loan { Id = 22, BookId = 10, MemberId = 26, LoanDate = new DateTime(2022, 12, 20), DueDate = new DateTime(2023, 1, 20), ReturnDate = new DateTime(2023, 1, 15) },
                new Loan { Id = 23, BookId = 13, MemberId = 28, LoanDate = new DateTime(2022, 11, 30), DueDate = new DateTime(2022, 12, 30), ReturnDate = new DateTime(2022, 12, 25) },
                new Loan { Id = 24, BookId = 16, MemberId = 30, LoanDate = new DateTime(2022, 10, 15), DueDate = new DateTime(2022, 11, 15), ReturnDate = new DateTime(2022, 11, 10) },
                new Loan { Id = 25, BookId = 19, MemberId = 1, LoanDate = new DateTime(2022, 9, 5), DueDate = new DateTime(2022, 10, 5), ReturnDate = new DateTime(2022, 9, 30) },
                new Loan { Id = 26, BookId = 22, MemberId = 3, LoanDate = new DateTime(2022, 8, 12), DueDate = new DateTime(2022, 9, 12), ReturnDate = new DateTime(2022, 9, 8) },
                new Loan { Id = 27, BookId = 25, MemberId = 5, LoanDate = new DateTime(2022, 7, 18), DueDate = new DateTime(2022, 8, 18), ReturnDate = new DateTime(2022, 8, 15) },
                new Loan { Id = 28, BookId = 28, MemberId = 7, LoanDate = new DateTime(2022, 6, 25), DueDate = new DateTime(2022, 7, 25), ReturnDate = new DateTime(2022, 7, 20) },

                // Multiple loans by same members
                new Loan { Id = 29, BookId = 1, MemberId = 1, LoanDate = new DateTime(2023, 5, 10), DueDate = new DateTime(2023, 6, 10), ReturnDate = new DateTime(2023, 6, 5) },
                new Loan { Id = 30, BookId = 3, MemberId = 1, LoanDate = new DateTime(2023, 7, 15), DueDate = new DateTime(2023, 8, 15), ReturnDate = new DateTime(2023, 8, 10) },
                new Loan { Id = 31, BookId = 6, MemberId = 3, LoanDate = new DateTime(2023, 4, 20), DueDate = new DateTime(2023, 5, 20), ReturnDate = new DateTime(2023, 5, 15) },
                new Loan { Id = 32, BookId = 9, MemberId = 3, LoanDate = new DateTime(2023, 6, 10), DueDate = new DateTime(2023, 7, 10), ReturnDate = new DateTime(2023, 7, 5) },
                new Loan { Id = 33, BookId = 12, MemberId = 5, LoanDate = new DateTime(2023, 3, 15), DueDate = new DateTime(2023, 4, 15), ReturnDate = new DateTime(2023, 4, 10) },
                new Loan { Id = 34, BookId = 15, MemberId = 5, LoanDate = new DateTime(2023, 5, 25), DueDate = new DateTime(2023, 6, 25), ReturnDate = new DateTime(2023, 6, 20) },
                new Loan { Id = 35, BookId = 18, MemberId = 7, LoanDate = new DateTime(2023, 2, 28), DueDate = new DateTime(2023, 3, 28), ReturnDate = new DateTime(2023, 3, 25) },
                new Loan { Id = 36, BookId = 21, MemberId = 7, LoanDate = new DateTime(2023, 4, 12), DueDate = new DateTime(2023, 5, 12), ReturnDate = new DateTime(2023, 5, 8) },
                new Loan { Id = 37, BookId = 24, MemberId = 9, LoanDate = new DateTime(2023, 1, 20), DueDate = new DateTime(2023, 2, 20), ReturnDate = new DateTime(2023, 2, 15) },
                new Loan { Id = 38, BookId = 27, MemberId = 9, LoanDate = new DateTime(2023, 3, 8), DueDate = new DateTime(2023, 4, 8), ReturnDate = new DateTime(2023, 4, 3) },
                new Loan { Id = 39, BookId = 4, MemberId = 11, LoanDate = new DateTime(2023, 6, 15), DueDate = new DateTime(2023, 7, 15), ReturnDate = new DateTime(2023, 7, 10) },
                new Loan { Id = 40, BookId = 7, MemberId = 11, LoanDate = new DateTime(2023, 8, 22), DueDate = new DateTime(2023, 9, 22), ReturnDate = new DateTime(2023, 9, 18) },
                new Loan { Id = 41, BookId = 10, MemberId = 13, LoanDate = new DateTime(2023, 7, 5), DueDate = new DateTime(2023, 8, 5), ReturnDate = new DateTime(2023, 8, 1) },
                new Loan { Id = 42, BookId = 13, MemberId = 13, LoanDate = new DateTime(2023, 9, 12), DueDate = new DateTime(2023, 10, 12), ReturnDate = new DateTime(2023, 10, 8) },
                new Loan { Id = 43, BookId = 16, MemberId = 15, LoanDate = new DateTime(2023, 8, 18), DueDate = new DateTime(2023, 9, 18), ReturnDate = new DateTime(2023, 9, 15) },
                new Loan { Id = 44, BookId = 19, MemberId = 15, LoanDate = new DateTime(2023, 10, 25), DueDate = new DateTime(2023, 11, 25), ReturnDate = new DateTime(2023, 11, 20) },
                new Loan { Id = 45, BookId = 22, MemberId = 17, LoanDate = new DateTime(2023, 9, 30), DueDate = new DateTime(2023, 10, 30), ReturnDate = new DateTime(2023, 10, 25) },
                new Loan { Id = 46, BookId = 25, MemberId = 17, LoanDate = new DateTime(2023, 11, 8), DueDate = new DateTime(2023, 12, 8), ReturnDate = new DateTime(2023, 12, 3) },
                new Loan { Id = 47, BookId = 28, MemberId = 19, LoanDate = new DateTime(2023, 10, 15), DueDate = new DateTime(2023, 11, 15), ReturnDate = new DateTime(2023, 11, 10) },
                new Loan { Id = 48, BookId = 2, MemberId = 19, LoanDate = new DateTime(2023, 12, 3), DueDate = new DateTime(2024, 1, 3), ReturnDate = new DateTime(2023, 12, 28) },
                new Loan { Id = 49, BookId = 5, MemberId = 21, LoanDate = new DateTime(2023, 11, 20), DueDate = new DateTime(2023, 12, 20), ReturnDate = new DateTime(2023, 12, 15) },
                new Loan { Id = 50, BookId = 8, MemberId = 21, LoanDate = new DateTime(2024, 1, 8), DueDate = new DateTime(2024, 2, 8), ReturnDate = null }
            };
        }
      
    }
}


