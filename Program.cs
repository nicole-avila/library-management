namespace libraryManagement
{
    // I load the library data from a file using the LoadData method of the HandleLibraryData class. 
    //I then create a new Library object and pass the loaded data to it. 
    //Finally, I create a new ConsoleInterface object and run the console interface.
    internal class Program
    {
        static void Main(string[] args)
        {
            HandleLibraryData loadedData = HandleLibraryData.LoadData();
            Library library = new Library
            {
                Books = loadedData.AllBooks,
                Authors = loadedData.AllAuthors
            };

            ConsoleInterface consoleInterface = new ConsoleInterface(library);
            consoleInterface.Run();
        }
    }
}
