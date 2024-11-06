namespace libraryManagement
{
    // In this class I have created a Library class that contains a list of books and authors. 
    //for each of these lists, I have created methods to add, remove, search, and filter the items in the list. 
    //I have also created methods to update the details of a book or author.
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Author> Authors { get; set; } = new List<Author>();

    // ALL BOOKS METHODS
    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void UpdateBook(Book updatedBook)
    {
        var book = Books.FirstOrDefault(b => b.Id == updatedBook.Id);
        if (book != null)
        {
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Genre = updatedBook.Genre;
            book.PublicationYear = updatedBook.PublicationYear;
            book.Isbn = updatedBook.Isbn;
        }
    }

    public void RemoveBook(int id)
    {
        Books.RemoveAll(bookItem => bookItem.Id == id);
    }

    public List<Book> FilterBooksByYear(int year)
    {
        return Books.Where(bookItem => bookItem.PublicationYear == year).ToList();
    }

    public List<Book> SearchBooks(string searchTerm)
    {
        return Books.Where(bookItem => 
            bookItem.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || 
            bookItem.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }


    // ALL AUTHORS METHODS
    public void AddAuthor(Author author)
    {
        author.Id = Authors.Count + 1;
        Authors.Add(author);
    }

    public void UpdateAuthor(Author updatedAuthor)
    {
        var author = Authors.FirstOrDefault(a => a.Id == updatedAuthor.Id);
        if (author != null)
        {
            author.Name = updatedAuthor.Name;
            author.Country = updatedAuthor.Country;
        }
    }

    public void RemoveAuthor(int id)
    {
        Authors.RemoveAll(authorItem => authorItem.Id == id);
    }

    public List<Author> FilterAuthorsByName()
    {
        return Authors.OrderBy(authorItem => authorItem.Name).ToList();

    }

    public List<Author> SearchAuthors(string searchTerm)
    {
        return Authors.Where(authorItem => 
            authorItem.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || 
            authorItem.Country.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }  
    } 
}
