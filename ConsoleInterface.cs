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
                        BookFunctions.AddNewBook(Library);
                        break;
                    case "2":
                        AuthorFunctions.AddNewAuthor(Library);
                        break;
                    case "3":
                        BookFunctions.UpdateBookDetails(Library);
                        break;
                    case "4":
                        AuthorFunctions.UpdateAuthorDetails(Library);
                        break;
                    case "5":
                        BookFunctions.RemoveBook(Library);
                        break;
                    case "6":
                        AuthorFunctions.RemoveAuthor(Library);
                        break;
                    case "7":
                        ListAllBooksAndAuthors();
                        break;
                    case "8":
                        // SearchAndFilterBooks();
                        Console.WriteLine("Search and filter books are not implemented yet - coming soon...");
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
            Console.WriteLine("8. Search and filter books - (Alert! You cannot perform this selection yet)");
            Console.WriteLine("9. Exit and save data");
            Console.Write("Enter your choice: ");
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