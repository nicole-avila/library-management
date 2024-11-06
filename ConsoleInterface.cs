namespace libraryManagement
{
    // In this class I have created a ConsoleInterface class that contains methods to display a menu and handle user input. 
    //The ConsoleInterface class interacts with the Library class to add, update, and remove books and authors, as well as list all books and authors in the library.
    
    public class ConsoleInterface
    {
         public Library Library { get; set; }

    public ConsoleInterface(Library lib)
    {
        Library = lib;
    }

  public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            DisplayMenu();
            string userInput = Console.ReadLine()!;
            switch (userInput)
            {
                case "1":
                    AddNewBook();
                    break;
                case "2":
                    AddNewAuthor();
                    break;
                case "3":
                    UpdateBookDetails();
                    break;
                case "4":
                    UpdateAuthorDetails();
                    break;
                case "5":
                    RemoveBook();
                    break;
                case "6":
                    RemoveAuthor();
                    break;
                case "7":
                    ListAllBooksAndAuthors();
                    break;
                case "8":
                    // SearchAndFilterBooks();
                    Console.WriteLine("Search and filter books are not implemented yet - coming soon!");
                    break;
                case "9":
                    SaveAndExit();
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again!");
                    break;
            }
        }
    }

    public void DisplayMenu()
    {
        Console.WriteLine("\n----Library Management System----");
        Console.WriteLine("1. Add new book");
        Console.WriteLine("2. Add new author");
        Console.WriteLine("3. Update book details");
        Console.WriteLine("4. Update author details");
        Console.WriteLine("5. Remove book");
        Console.WriteLine("6. Remove author");
        Console.WriteLine("7. List all books and authors");
        Console.WriteLine("8. Search and filter books - (Alert! You cannot perform this selection yet...coming soon)");
        Console.WriteLine("9. Exit and save data");
        Console.Write("Enter your choice: ");
    }

    public void AddNewBook()
    {
        Console.WriteLine("--Enter Book Details--");

        const int maxAttempts = 3; 
        int attempts = 0; 

        while (attempts < maxAttempts)
        {
            Console.Write("First, enter a new book ID number: ");
            string userBookIdInput = Console.ReadLine()!;

            if (int.TryParse(userBookIdInput, out int id))
            {
                var book = Library.Books.FirstOrDefault(bookItem => bookItem.Id == id);

                if (book == null)
                {
                    Book newBook = new Book(id, "", "", "", 0, "");
                    Console.Write("Title: ");
                    newBook.Title = Console.ReadLine()!;
                    Console.Write("Author: ");
                    newBook.Author = Console.ReadLine()!;
                    Console.Write("Genre: ");
                    newBook.Genre = Console.ReadLine()!;
                    Console.Write("Publication Year: ");
                    if (int.TryParse(Console.ReadLine(), out int year))
                    {
                        newBook.PublicationYear = year;
                    }
                    Console.Write("ISBN: ");
                    newBook.Isbn = Console.ReadLine()!;

                    Library.AddBook(newBook);
                    Console.WriteLine("Book added successfully!");
                    return;
                }
                else
                {
                    Console.WriteLine("Book with the specified ID already exists. Please enter a different ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID");
            }
            attempts++; 
            Console.WriteLine($"You have {maxAttempts - attempts} attempt(s) left!");
        }
        Console.WriteLine("You have exceeded the maximum number of attempts.");
    }

      public void AddNewAuthor()
    {
        Console.WriteLine("--Enter Author Details--");
        
        const int maxAttempts = 3; 
        int attempts = 0; 

        while (attempts < maxAttempts)
        {
            Console.Write("First, enter a new author ID number: ");
            string userAuthorIdInput = Console.ReadLine()!;

            if (int.TryParse(userAuthorIdInput, out int id))
            {
                var author = Library.Authors.FirstOrDefault(authorItem => authorItem.Id == id);

                if (author == null)
                {
                    Author newAuthor = new Author(id, "", "");
                    Console.Write("Name: ");
                    newAuthor.Name = Console.ReadLine()!;
                    Console.Write("Country: ");
                    newAuthor.Country = Console.ReadLine()!;

                    Library.AddAuthor(newAuthor);
                    Console.WriteLine("Author added successfully!");
                    return;
                }
                else
                {
                    Console.WriteLine("Author with the specified ID already exists. Please enter a different ID");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID");
            }
            attempts++; 
            Console.WriteLine($"You have {maxAttempts - attempts} attempt(s) left!");
        }
        Console.WriteLine("You have exceeded the maximum number of attempts");
    }

    public void UpdateBookDetails()
    {
        Console.Write("Enter book - id - to update: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var book = Library.Books.FirstOrDefault(bookItem => bookItem.Id == id);
            if (book != null)
            {
                Console.WriteLine("Enter new details (press ENTER to keep current value):");
                Console.Write($"Title ({book.Title}): ");
                string input = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(input)) book.Title = input;

                Console.Write($"Author ({book.Author}): ");
                input = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(input)) book.Author = input;

                Console.Write($"Genre ({book.Genre}): ");
                input = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(input)) book.Genre = input;

                Console.Write($"Publication Year ({book.PublicationYear}): ");
                input = Console.ReadLine()!;
                if (int.TryParse(input, out int year)) book.PublicationYear = year;

                Console.Write($"ISBN ({book.Isbn}): ");
                input = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(input)) book.Isbn = input;

                Library.UpdateBook(book);
                Console.WriteLine("Book updated successfully!");
            }
            else
            {
                Console.WriteLine("Sorry, Book not found");
            }
        }
        else
        {
            Console.WriteLine("Invalid Id");
        }
    }

     public void UpdateAuthorDetails()
    {
        Console.Write("Enter author - id - to update: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var author = Library.Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                Console.WriteLine("Enter new details (press ENTER to keep current value):");
                Console.Write($"Name ({author.Name}): ");
                string input = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(input)) author.Name = input;

                Console.Write($"Country ({author.Country}): ");
                input = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(input)) author.Country = input;

                Library.UpdateAuthor(author);
                Console.WriteLine("Author updated successfully!");
                 }
            else
            {
                Console.WriteLine("Sorry, Author not found");
            }
        }
        else
        {
            Console.WriteLine("Invalid Id");
        }
    }

    public void RemoveBook()
    {
        const int maxAttempts = 3; 
        int attempts = 0; 

        while (attempts < maxAttempts)
        {
            Console.Write("Enter Book - ID - to remove: ");
            string userRemoveInput = Console.ReadLine()!;

            if (int.TryParse(userRemoveInput, out int id))
            {   
                var bookToRemove = Library.Books.FirstOrDefault(bookItem => bookItem.Id == id);

                if(bookToRemove != null)
                {
                    Library.RemoveBook(id);
                    Console.WriteLine($"Book '{bookToRemove.Title}' removed successfully!");
                    return;
                }
                else
                {
                    Console.WriteLine("__Book not found with the specified ID__");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID");
            }
            attempts++; 
            Console.WriteLine($"You have {maxAttempts - attempts} attempt(s) left!");
        }
        Console.WriteLine("You have exceeded the maximum number of attempts.");
    }


     public void RemoveAuthor()
    {
        const int maxAttempts = 3; 
        int attempts = 0; 

        while (attempts < maxAttempts)
        {
            Console.Write("Enter Author - ID - to remove: ");
            string userRemoveInput = Console.ReadLine()!;

            if (int.TryParse(userRemoveInput, out int id))
            {
                var authorToRemove = Library.Authors.FirstOrDefault(author => author.Id == id);
                
                if (authorToRemove != null)
                {
                    Library.RemoveAuthor(id);
                    Console.WriteLine($"Author '{authorToRemove.Name}' removed successfully!");
                    return;
                }
                else
                {
                    Console.WriteLine("Author not found with the specified ID");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID");
            }
            attempts++; 
            Console.WriteLine($"You have {maxAttempts - attempts} attempt(s) left.");
        }
        Console.WriteLine("You have exceeded the maximum number of attempts.");
    }

     public void ListAllBooksAndAuthors()
    {
        Console.WriteLine("\n----A list of all Books----");
        foreach (var book in Library.Books)
        {
            Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Year: {book.PublicationYear}, ISBN: {book.Isbn}");
        }

        Console.WriteLine("\n----A list of all Authors----");
        foreach (var author in Library.Authors)
        {
            Console.WriteLine($"Id: {author.Id}, Name: {author.Name}, Country: {author.Country}");
        }
    }
        
    public void SaveAndExit()
    {
        HandleLibraryData libraryData = new HandleLibraryData
        {
            AllBooks = Library.Books,
            AllAuthors = Library.Authors
        };

        libraryData.SaveData();

        Console.WriteLine("Data has been saved successfully. Exiting...");
    }
    } 
}