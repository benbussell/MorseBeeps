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
                Console.WriteLine("2. View a list of common phrases");
                Console.WriteLine("3. Add a new word or phrase to the list");
                Console.WriteLine("4. Remove a word or phrase from the list");
                Console.WriteLine("5. Exit");
                Console.WriteLine("------------------------------------------");
            
                string userChoice = Console.ReadLine();

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
                                Console.WriteLine("Enter 'B' to hear the code or enter 'Q' to exit to main menu");
                                string bString = Console.ReadLine();

                                    char[] dotNDash = Beeps.PlayMessage(translate);
                                    Console.WriteLine(dotNDash[]);
                               
                            }






                        }

                        break;

                    case "2":

                        string currentDirectory = Directory.GetCurrentDirectory();
                        DirectoryInfo directory = new DirectoryInfo(currentDirectory);
                        var fileName = Path.Combine(directory.FullName, "phrases.txt");
                        var file = new FileInfo(fileName);
                        if (file.Exists)
                        {
                            using (var reader = new StreamReader(file.FullName))
                            {
                                Console.SetIn(reader);
                                Console.WriteLine(Console.ReadLine());
                            }

                        }
                        break;

                    case "3":
                        Console.WriteLine("Case 3");
                        break;
                    case "4":
                        Console.WriteLine("Case 4");
                        break;
                    case "5":

                        break;
                    default:
                        Console.WriteLine("Please Try Again");
                }
            
        }
    }
}