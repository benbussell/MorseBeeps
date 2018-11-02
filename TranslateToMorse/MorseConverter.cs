using System.Collections.Generic;

namespace TranslateToMorse
{
    static class MorseConverter
    {
        private static Dictionary<char, string> _letterCode = new Dictionary<char, string>
        {
            {' ', "/"},
            {'A', ".-"},
            {'B', "-..."},
            {'C', "-.-."}, 
            {'D', "-.."},
            {'E', "."},
            {'F', "..-."},
            {'G', "--."},
            {'H', "...."},
            {'I', ".."},
            {'J', ".---"},
            {'K', "-.-"},
            {'L', ".-.."},
            {'M', "--"},
            {'N', "-."},
            {'O', "---"},
            {'P', ".--."},
            {'Q', "--.-"},
            {'R', ".-."},
            {'S', "..."},
            {'T', "-"},
            {'U', "..-"},
            {'V', "...-"},
            {'W', ".--"},
            {'X', "-..-"},
            {'Y', "-.--"},
            {'Z', "--.."},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
            {'0', "-----"},
            {',', "--..--"},
            {'.', ".-.-.-"},
            {'?', "..--.."},
            {';', "-.-.-."},
            {':', "---..."},
            {'/', "-..-."},
            {'-', "-....-"},
            {'\'', ".----."},
            {'"', ".-..-."},
            {'(', "-.--."},
            {')', "-.--.-"},
            {'=', "-...-"},
            {'+', ".-.-."},
            {'@', ".--.-."},
            {'!', "-.-.--"},
            {'Á', ".--.-"},
            {'É', "..-.."},
            {'Ö', "---."},
            {'Ä', ".-.-"},
            {'Ñ', "--.--"},
            {'Ü', "..--"}
            };

        public static string ToMorseCode (string input)
        {
            List<string> translated = new List<string>(input.Length);
            
                foreach (char letter in input.ToUpper())
                {
                    try
                    {
                        string morseCode = _letterCode[letter];
                        translated.Add(morseCode);
                    }
                    catch (KeyNotFoundException)
                    {
                    translated.Add("key unavailable");
                    }
                }
            var result =  string.Join(" ", translated);
            return result;
        }

        public static char[] PlayMessage(string bInput)
        {
            string morseText = ToMorseCode(bInput);
            char[] dotNDash = bInput.ToCharArray();
            return dotNDash;
            foreach(char character in dotNDash)
            {

            }
        }
    }
}
