using System;
using System.Collections.Generic;
using System.IO;

namespace TranslateToMorse
{
    class Program
    {
        public static void Main(string[] args)
        {
            string userChoice = string.Empty;
            while (userChoice != "5")
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("    Welcome to the Morse Translator!");
                Console.WriteLine("       What would you like to do?");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Translate a word or phrase");
                Console.WriteLine("2. Select a popular quote at random");
                Console.WriteLine("3. View list of favorite quotes");
                Console.WriteLine("4. Exit");
                Console.WriteLine("------------------------------------------");
                //main menu

                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":

                        while (true)
                        {
                            Console.Write("Please enter a word or phrase to translate:  ");
                            string input = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(input))
                            {
                                break;
                            }

                            string translate = MorseConverter.ToMorseCode(input);
                            //convert alphanumeric user input text to Morse dots and dashes

                            Console.WriteLine(translate);

                            string bString = string.Empty;
                            while (bString.ToLower() != "m")
                            {
                                Console.WriteLine("Enter 'P' to play the code");
                                Console.WriteLine("Enter 'S' to save this to your favorite phrases");
                                Console.WriteLine("Enter 'M' to exit to main menu");
                                //secondary menu

                                bString = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(bString))
                                {
                                    break;
                                }

                                if (bString.ToLower() == "p")
                                {
                                    MorseConverter.PlayMessage(translate);
                                    //beeps morse code back through computer audio out
                                }

                                if (bString.ToLower() == "s")
                                {
                                    Console.WriteLine("Please enter your name: ");
                                    string userName = Console.ReadLine();
                                    //user name will be used as Author value in Quote object

                                    Quote userQuote = new Quote
                                    {
                                        Author = userName,
                                        Text = input,
                                        Likes = "0"
                                    };
                                    //convert user input into instance of Quote object

                                    SaveQuotesToFile.SaveQuote(userQuote);
                                    //Add new Quote to list of favorites and save to file
                                }

                                if (bString.ToLower() == "m")
                                {
                                    break;
                                }
                            }
                            break;
                        }
                        break;

                    case "2":

                        Quote randQuote = RandomQuoteGenerator.GetRandomQuote();
                        //select popular quote at random from downloaded dataset

                        Console.WriteLine(randQuote.Text + "-" + randQuote.Author);
                        Console.WriteLine("-------------------------------------------------");

                        string translateQuote = MorseConverter.ToMorseCode(randQuote.Text);
                        Console.WriteLine("In Morse Code this reads: " + translateQuote);
                        //convert randomly selected quote from alpanumeric text to Morse dots and dashes

                        string cString = string.Empty;
                        while (cString.ToLower() != "b")
                        {
                            Console.WriteLine("Enter 'P' to play the code");
                            Console.WriteLine("Enter 'S' to save this to your favorite phrases");
                            Console.WriteLine("Enter 'B' to go back");
                            
                            //secondary menu

                            cString = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(cString))
                            {
                                break;
                            }

                            if (cString.ToLower() == "p")
                            {
                                MorseConverter.PlayMessage(translateQuote);
                                //beeps morse code back through computer audio out
                            }

                            if (cString.ToLower() == "s")
                            {
                                SaveQuotesToFile.SaveQuote(randQuote);
                                //Add new Quote to list of favorites and save to file
                            }

                            if (cString.ToLower() == "b")
                            {
                                break;
                            }
                        }
                        break;

                    case "3":
                        //generate numbered list of saved quotes and phrases from json file
                        

                        string dString = String.Empty;
                        while (dString.ToLower() != "m")
                        {
                            List<Quote> quotes =FavoritesList.PrintList(); 
                                for(int i = 0; i < quotes.Count; i++)
                                {
                                    Console.WriteLine($"{i+1}.  {quotes[i].Text}  -{quotes[i].Author} ");
                                }
                            Console.WriteLine("---------------------------------------------------------------------");
                            Console.WriteLine("Select the number of a quote from the list or enter 'M' for Main Menu");
                            dString = Console.ReadLine();
                            if (dString.ToLower() == "m")
                            {
                                break;
                            }
                            int s = Int32.Parse(dString);
                            Quote quoteText = quotes[s - 1];
                            FavoritesList.QuoteSelectMenu(quotes, quoteText);
                        }
                        break;
                       
                    case "4":
                        break;

                    default:
                        Console.WriteLine("Please Try Again");
                        break;
                }
            }
        }

        
    }
}