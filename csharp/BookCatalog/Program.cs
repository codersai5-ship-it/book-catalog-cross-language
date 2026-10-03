namespace BookCatalog;

internal class Program
{
    // Generic List<T> provides strongly typed collection storage.
    private static readonly List<Book> Books = new()
    {
        new Book("Clean Code", "Robert C. Martin", "Software Engineering", 2008),
        new Book("The Pragmatic Programmer", "Andrew Hunt and David Thomas", "Software Engineering", 1999),
        new Book("1984", "George Orwell", "Fiction", 1949)
    };

    private static void Main()
    {
        bool running = true;
        Console.WriteLine("=== Book Cataloging System - C# ===");

        while (running)
        {
            DisplayMenu();
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1": AddBook(); break;
                case "2": RemoveBook(); break;
                case "3": DisplayAllBooks(); break;
                case "4": SearchByTitle(); break;
                case "5": SearchByAuthor(); break;
                case "6": SearchByGenre(); break;
                case "7": ReportByAuthor(); break;
                case "8": ReportByGenre(); break;
                case "0": running = false; break;
                default: Console.WriteLine("Invalid option. Please choose 0-8."); break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Goodbye!");
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. Remove Book");
        Console.WriteLine("3. Display All Books");
        Console.WriteLine("4. Search by Title");
        Console.WriteLine("5. Search by Author");
        Console.WriteLine("6. Search by Genre");
        Console.WriteLine("7. Report by Author");
        Console.WriteLine("8. Report by Genre");
        Console.WriteLine("0. Exit");
    }

    private static void AddBook()
    {
        string title = ReadRequired("Title: ");
        string author = ReadRequired("Author: ");
        string genre = ReadRequired("Genre: ");
        int year = ReadYear();

        Books.Add(new Book(title, author, genre, year));
        Console.WriteLine("Book added successfully.");
    }

    private static void RemoveBook()
    {
        string title = ReadRequired("Enter the title to remove: ");

        // LINQ FirstOrDefault finds the first matching object in the collection.
        Book? book = Books.FirstOrDefault(b =>
            b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (book is null)
        {
            Console.WriteLine("No matching book was found.");
            return;
        }

        Books.Remove(book);
        Console.WriteLine($"Removed: {book.Title}");
    }

    private static void DisplayAllBooks()
    {
        DisplayResults(Books.OrderBy(b => b.Title), "All Books");
    }

    private static void SearchByTitle()
    {
        string search = ReadRequired("Enter title search text: ");
        var results = Books.Where(b =>
            b.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
        DisplayResults(results, $"Title Search: {search}");
    }

    private static void SearchByAuthor()
    {
        string search = ReadRequired("Enter author search text: ");
        var results = Books.Where(b =>
            b.Author.Contains(search, StringComparison.OrdinalIgnoreCase));
        DisplayResults(results, $"Author Search: {search}");
    }

    private static void SearchByGenre()
    {
        string search = ReadRequired("Enter genre search text: ");
        var results = Books.Where(b =>
            b.Genre.Contains(search, StringComparison.OrdinalIgnoreCase));
        DisplayResults(results, $"Genre Search: {search}");
    }

    private static void ReportByAuthor()
    {
        Console.WriteLine("--- Books by Author ---");

        // LINQ GroupBy creates author-based groups for reporting.
        var groups = Books
            .GroupBy(b => b.Author, StringComparer.OrdinalIgnoreCase)
            .OrderBy(g => g.Key);

        foreach (var group in groups)
        {
            Console.WriteLine($"\n{group.Key} ({group.Count()} book(s))");
            foreach (Book book in group.OrderBy(b => b.Title))
                Console.WriteLine($"  - {book.Title} ({book.PublicationYear}) | {book.Genre}");
        }
    }

    private static void ReportByGenre()
    {
        Console.WriteLine("--- Books by Genre ---");

        // LINQ GroupBy demonstrates concise collection querying in C#.
        var groups = Books
            .GroupBy(b => b.Genre, StringComparer.OrdinalIgnoreCase)
            .OrderBy(g => g.Key);

        foreach (var group in groups)
        {
            Console.WriteLine($"\n{group.Key} ({group.Count()} book(s))");
            foreach (Book book in group.OrderBy(b => b.Title))
                Console.WriteLine($"  - {book.Title} by {book.Author} ({book.PublicationYear})");
        }
    }

    private static void DisplayResults(IEnumerable<Book> results, string heading)
    {
        List<Book> matches = results.ToList();
        Console.WriteLine($"--- {heading} ---");

        if (!matches.Any())
        {
            Console.WriteLine("No books found.");
            return;
        }

        foreach (Book book in matches)
            Console.WriteLine(book);
    }

    private static string ReadRequired(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string value = Console.ReadLine()?.Trim() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(value))
                return value;

            Console.WriteLine("This field cannot be empty.");
        }
    }

    private static int ReadYear()
    {
        while (true)
        {
            Console.Write("Publication year: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int year) && year > 0 && year <= DateTime.Now.Year)
                return year;

            Console.WriteLine("Enter a valid publication year.");
        }
    }
}
