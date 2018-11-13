using System;
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

                            Console.WriteLine(translate);

                            string bString = string.Empty;
                            while (bString != "q" && bString != "Q")
                            {
                                Console.WriteLine("Enter 'B' to hear the code");
                                Console.WriteLine("Enter 'S' to save this to your favorite phrases");
                                Console.WriteLine("Enter 'Q' to exit to main menu");


                                bString = Console.ReadLine();

                                if (bString.ToLower() == "b")
                                {
                                    MorseConverter.PlayMessage(translate);
                                }

                                if (bString.ToLower() == "s")
                                {
                                    SaveQuote(input);
                                }
                            }
                            break;
                        }
                        break;

                    case "2":

                        Quote randQuote = RandomQuoteGenerator.GetRandomQuote();
                        Console.WriteLine(randQuote.Text + "-" + randQuote.Author);
                        Console.WriteLine("-------------------------------------------------");

                        string translateQuote = MorseConverter.ToMorseCode(randQuote.Text);
                        Console.WriteLine("In Morse Code this reads: " + translateQuote);

                        string cString = string.Empty;
                        while (cString != "q" && cString != "Q")
                        {
                            Console.WriteLine("Enter 'B' to hear the code");
                            Console.WriteLine("Enter 'S' to save this to your favorite phrases");
                            Console.WriteLine("Enter 'Q' to exit to main menu");


                            cString = Console.ReadLine();

                            if (cString.ToLower() == "b")
                            {
                                MorseConverter.PlayMessage(translateQuote);
                            }

                            if (cString.ToLower() == "s")
                            {
                                SaveQuote(randQuote.Text + "-" + randQuote.Author);
                            }
                        }
                        break;

                    case "3":

                        break;

                    case "4":

                        break;

                    default:
                        Console.WriteLine("Please Try Again");
                        break;
                }
            }
        }

        public static void SaveQuote(string input)
        {
            Console.WriteLine(input);
        }
    }
}