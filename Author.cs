namespace libraryManagement
{
    public class Author
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }

    public Author(int id, string name, string country)
    {
        Id = id;
        Name = name;
        Country = country;
      
    }
    }
}