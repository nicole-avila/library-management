namespace libraryManagement
{
    public class Author
    {
      public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();
    }
    
}