using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TranslateToMorse
{
    class SaveQuotesToFile
    {
        public static void SaveQuote(Quote newFave)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "favorites.json"); 
            var listOfFavorites = DeserializeList(fileName);
            listOfFavorites.Add(newFave);
            SerializeQuotes(listOfFavorites, fileName);
            Console.WriteLine($"You have successfully saved this quote by {newFave.Author}.");
            Console.WriteLine("------------------------------------------------------------");
        }
        //saves a new favorite quote to the file favorites.json

        public static List<Quote> DeserializeList(string fileName)
        {
            var listOfFavorites = new List<Quote>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                listOfFavorites = serializer.Deserialize<List<Quote>>(jsonReader);
            }           
            return listOfFavorites;           
        }
        //deserializes json file and creates list of type Quote

        public static void SerializeQuotes(List<Quote> listOfFavorites, string fileName)
        {       
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, listOfFavorites);
            }  
        }
        //serializes list of quotes to be written to file

        public static void RemoveQuote(Quote nope)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "favorites.json");
            var listOfFavorites = DeserializeList(fileName);
            //returns deserialized list of favorite quotes

            int nopeIndex = -1;
            for(var i = 0; i < listOfFavorites.Count; i++ )
            {
                var quote = listOfFavorites[i];
                if(quote.Text == nope.Text)
                {
                    nopeIndex = i;
                }       
            }
            if(nopeIndex >= 0)
            {
                listOfFavorites.RemoveAt(nopeIndex);
            }
            //removes a selected quote from the file favorites.json
            SerializeQuotes(listOfFavorites, fileName);
            //re-serializes the list and writes it to the file
        }
        
    }
}
