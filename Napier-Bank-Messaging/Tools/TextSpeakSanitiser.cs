using System.Collections.Generic;
using System.Linq;
using System.IO;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Tools
{
    public class TextSpeakSanitiser
    {
        // function to sanitise text speak words
        public string Sanatise(List<string> body)
        {
            // get all words from file
            List<TextSpeak> wordsList = GetTextSpeakerValues();
            // split message body into single words
            List<string> messageBody = body[1].Split(" ").ToList();
            // create dictionary for faster searching
            Dictionary<string, string> words = new Dictionary<string, string>();
            // create start of return string
            string sanitisedBody = body[0] + "\n";

            // foreach through all text speak words and add text speak object into dictionary
            foreach (TextSpeak word in wordsList)
            {
                words.Add(word.Abbreviation, word.Phrase);
            }

            // foreach through body of message
            foreach (string message in messageBody)
            {
                // if dictionary includes key then sanitise string
                if (words.ContainsKey(message))
                {
                    sanitisedBody = sanitisedBody + " " + message + " <" + words[message] + ">";
                    continue;
                }

                // if key isn't included then add normal message back to return string
                sanitisedBody = sanitisedBody + " " + message;
            }

            // return sanitised body
            return sanitisedBody;
        }

        // fucntion to get text speak values from csv file
        private static List<TextSpeak> GetTextSpeakerValues()
        {
            // add all values from csv file to string array
            string[] values = File.ReadAllLines(FilePathEnum.TextWordsFilePath);
            // list of text speak objects
            List<TextSpeak> allValues = new List<TextSpeak>();
            
            // foreach through eaach row of the csv file values
            foreach (string value in values)
            {
                // split row into key => value
                string[] row = value.Split(",");
                // create new text speak object
                TextSpeak textSpeak = new TextSpeak();

                // add key to abbreviation value of text speak object
                textSpeak.Abbreviation = row[0];
                // add value to phrase value of text speak object
                textSpeak.Phrase = row[1];
                // add text speak object list
                allValues.Add(textSpeak);
            }

            // return list full of text speak objects
            return allValues;
        }
    }
}
