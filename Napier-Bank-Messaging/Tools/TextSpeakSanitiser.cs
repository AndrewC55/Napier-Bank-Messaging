using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Napier_Bank_Messaging.Tools
{
    public class TextSpeakSanitiser
    {
        private const string FilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\textwords.csv";

        public string Sanatise(List<string> body)
        {
            List<TextSpeak> wordsList = GetTextSpeakerValues();
            List<string> messageBody = body[1].Split(" ").ToList();
            Dictionary<string, string> words = new Dictionary<string, string>();
            string sanitisedBody = body[0] + "\n";

            foreach (TextSpeak word in wordsList)
            {
                words.Add(word.Abbreviation, word.Phrase);
            }

            foreach (string message in messageBody)
            {
                if (words.ContainsKey(message))
                {
                    sanitisedBody = sanitisedBody + " " + message + " <" + words[message] + ">";
                    continue;
                }

                sanitisedBody = sanitisedBody + " " + message;
            }

            return sanitisedBody;
        }

        private static List<TextSpeak> GetTextSpeakerValues()
        {
            string[] values = File.ReadAllLines(FilePath);
            List<TextSpeak> allValues = new List<TextSpeak>();
            
            foreach (string value in values)
            {
                string[] row = value.Split(",");
                TextSpeak textSpeak = new TextSpeak();

                textSpeak.Abbreviation = row[0];
                textSpeak.Phrase = row[1];
                allValues.Add(textSpeak);
            }

            return allValues;
        }
    }
}
