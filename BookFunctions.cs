namespace libraryManagement
{
    public static class BookFunctions
    {  
        public static void AddNewBook(Library Library)
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


        public static void UpdateBookDetails(Library Library)
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

        public static void RemoveBook(Library Library)
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
    }
} 