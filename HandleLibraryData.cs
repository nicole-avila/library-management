using System.Text.Json.Serialization;
using System.Text.Json;

namespace libraryManagement
{
    public class HandleLibraryData
    {
        [JsonPropertyName("Books")]
        public List<Book> AllBooks { get; set; } = new List<Book>();

        [JsonPropertyName("Authors")]
        public List <Author> AllAuthors { get; set; } = new List<Author>();

        public const string data = "LibraryData.json";

        // funktion för att ladda upp biblioteksdata från en JSON-fil
        public static HandleLibraryData LoadData()
        {   
            // om filen finns
            if (File.Exists(data))
            {   
            // läser in allt från filen
            string jsonString = File.ReadAllText(data);
            // deserialiserar JSON-strängen till ett HandleLibraryData-objekt
            return JsonSerializer.Deserialize<HandleLibraryData>(jsonString) ?? new HandleLibraryData();
            }
            // om filen inte finns, returnera ett nytt HandleLibraryData-objekt
            return new HandleLibraryData();
        }

        // funktion för att spara biblioteksdata till en JSON-fil
        public void SaveData()
        {
            // serialiserar objektet till en JSON-sträng
            string jsonString = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            // skriver JSON-strängen till filen
            File.WriteAllText(data, jsonString);
        }
    }
}

