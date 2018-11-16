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
            return listOfFavorites;
            //returns list of Quote objects from favorites.json

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
            //print out selected Quote in alphanumeric text and Morse text

            while (eString.ToLower() != "b")
            {
                Console.WriteLine("Please select from the options below");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Enter 'P' to play the code");
                Console.WriteLine("Enter 'R' to remove this quote from the list");
                Console.WriteLine("Enter 'B' to go back");
                //secondary menu

                eString = Console.ReadLine();
                switch (eString)
                {
                    case "p":
                        MorseConverter.PlayMessage(morse);
                        break;
                        //beeps morse code back through computer audio out

                    case "r":
                        SaveQuotesToFile.RemoveQuote(yourQuote);
                        Console.WriteLine("-----------------------------------------------------------------------");
                        Console.WriteLine($"You have successfully removed: {yourQuote.Text} by {yourQuote.Author}.");
                        break;
                        //removes selected quote from list of favorites

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
