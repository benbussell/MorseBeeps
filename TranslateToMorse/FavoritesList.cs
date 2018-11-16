using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TranslateToMorse
{
    static class FavoritesList
    {
        public static List<Quote> PrintList()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "favorites.json");
            var listOfFavorites = DeserializeList(fileName);
            //var fileContents = ReadFile(fileName);
            //Console.WriteLine(fileContents);
            return listOfFavorites;

        }
        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
                return reader.ReadToEnd();
        }

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

        public static void QuoteSelectMenu(List<Quote> quotes, Quote yourQuote)
        {
            string eString = string.Empty;
             
                Console.WriteLine("------------------------------------");
                Console.WriteLine("You have chosen:");
                Console.WriteLine(yourQuote.Text);
                string morse = MorseConverter.ToMorseCode(yourQuote.Text);
                Console.WriteLine(morse);

            while (eString.ToLower() != "b")
            {
                Console.WriteLine("Please select from the options below");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Enter 'P' to play the code");
                Console.WriteLine("Enter 'R' to remove this quote from the list");
                Console.WriteLine("Enter 'B' to go back");

                eString = Console.ReadLine();
                switch (eString)
                {
                    case "p":
                        MorseConverter.PlayMessage(morse);
                        break;

                    case "r":
                        SaveQuotesToFile.RemoveQuote(yourQuote);
                        Console.WriteLine("-----------------------------------------------------------------------");
                        Console.WriteLine($"You have successfully removed: {yourQuote.Text} by {yourQuote.Author}.");
                        break;

                    case "b":
                        break;

                    default:
                        Console.WriteLine("Please Try Again");
                        break;
                }
            }
        }

        

       
    }
}
