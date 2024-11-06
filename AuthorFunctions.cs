namespace libraryManagement
{
    public static class AuthorFunctions
    {
        public static void AddNewAuthor(Library Library)
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

        public static void UpdateAuthorDetails(Library Library)
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

        public static void RemoveAuthor(Library Library)
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
    }
}