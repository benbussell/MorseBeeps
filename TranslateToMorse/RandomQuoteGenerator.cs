using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace TranslateToMorse
{
    public class RandomQuoteGenerator
    {
        public static Quote GetRandomQuote()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "most_popular_quotes.json");
            //fetch json file of popular quotes from directory

            var quotes = DeserializeQuotes(fileName);
            var randQuote = SelectRandomFromList(quotes);
            return randQuote;
            //returns a random Quote object from the deserialized json dataset
        }

       public static List<Quote> DeserializeQuotes(string fileName)
        {
            var quotes = new List<Quote>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                quotes = serializer.Deserialize<List<Quote>>(jsonReader);
            }
            //deserialize list of quotes
            return quotes;

        }

        public static Quote SelectRandomFromList(List<Quote> quotes)
        {
            Random rndm = new Random();
            Quote randQuote = new Quote();
            randQuote = quotes[rndm.Next(quotes.Count)];
            return randQuote;
            //select a Quote object at random from json list
        }




    }


}
