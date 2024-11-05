namespace libraryManagement
{
    public class Book
    {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }
    public string Isbn { get; set; }
    public List<int> Reviews { get; set; } = new List<int>();


    public Book(int id, string title, string author, string genre, int publicationYear, string isbn)
    {
        Id = id;
        Title = title;
        Author = author;
        Genre = genre;
        PublicationYear = publicationYear;
        Isbn = isbn;
    }
    }
}