namespace BookCatalog;

/// <summary>
/// Represents one book in the catalog.
/// C# properties demonstrate the language's strongly typed object model.
/// </summary>
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }

    public Book(string title, string author, string genre, int publicationYear)
    {
        Title = title;
        Author = author;
        Genre = genre;
        PublicationYear = publicationYear;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} | Genre: {Genre} | Year: {PublicationYear}";
    }
}
