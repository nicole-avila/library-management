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
                    // UpdateAuthorDetails();
                    Console.WriteLine("Update Author Details");
                    break;
                case "5":
                    // RemoveBook();
                    Console.WriteLine("Remove Book");
                    break;
                case "6":
                    // RemoveAuthor();
                    Console.WriteLine("Remove Author");
                    break;
                case "7":
                    // ListAllBooksAndAuthors();
                    Console.WriteLine("List All Books and Authors");
                    break;
                case "8":
                    // SearchAndFilterBooks();
                    Console.WriteLine("Search and Filter Books");
                    break;
                case "9":
                    SaveAndExit();
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
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
        Console.WriteLine("8. Search and filter books");
        Console.WriteLine("9. Exit and save data");
        Console.Write("Enter your choice: ");
    }

    public void AddNewBook()
    {
        Console.WriteLine("--Enter book details--");
        Console.Write("First, enter a new book ID: ");
        int id = int.Parse(Console.ReadLine()!);
        Book book = new Book(id, "", "", "", 0, "");
        Console.Write("Title: ");
        book.Title = Console.ReadLine()!;
        Console.Write("Author: ");
        book.Author = Console.ReadLine()!;
        Console.Write("Genre: ");
        book.Genre = Console.ReadLine()!;
        Console.Write("Publication Year: ");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            book.PublicationYear = year;
        }
        Console.Write("ISBN: ");
        book.Isbn = Console.ReadLine()!;

        Library.AddBook(book);
        Console.WriteLine("Book added successfully!");
    }

      public void AddNewAuthor()
    {
        Console.WriteLine("Enter author details:");
        Console.Write("First, enter a new author ID: ");
        int authorId = int.Parse(Console.ReadLine()!);
        Author author = new Author(authorId, "", "");
        Console.Write("Name: ");
        author.Name = Console.ReadLine()!;
        Console.Write("Country: ");
        author.Country = Console.ReadLine()!;

        Library.AddAuthor(author);
        Console.WriteLine("Author added successfully.");
    }

    public void UpdateBookDetails()
    {
        Console.Write("Enter book ID to update: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var book = Library.Books.FirstOrDefault(bookItem => bookItem.Id == id);
            if (book != null)
            {
                Console.WriteLine("Enter new details (press Enter to keep current value):");
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
                Console.WriteLine("Book updated successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    // DU ÄR HÄR - FORTSÄTT MED ATT IMPLEMENTERA DE ANDRA METODERNA


        
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

    } // End of ConsoleInterface class
}