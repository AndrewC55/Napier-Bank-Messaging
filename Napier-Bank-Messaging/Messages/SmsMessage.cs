using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Napier_Bank_Messaging.Tools;

namespace Napier_Bank_Messaging.Messages
{
    public class SmsMessage : Message
    {
        public override void Sanatise(string header, string body)
        {
            TextSpeakSanitiser textSpeakSanitiser = new TextSpeakSanitiser();
            List<TextSpeak> wordsList = textSpeakSanitiser.GetTextSpeakerValues();
            List<string> listBody = GetFormattedListBody(body);
            List<string> messageBody = listBody[1].Split(" ").ToList();
            Dictionary<string, string> words = new Dictionary<string, string>();
            string sanitisedBody = listBody[0] + "\n";

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

            MessageHeader = header;
            MessageBody = sanitisedBody;
        }

        public override bool Format(string body)
        {
            List<string> listBody = GetFormattedListBody(body);
            return IsSenderCorrect(listBody[0]) && IsCharacterLengthCorrect(listBody[1]);
        }

        private bool IsSenderCorrect(string sender)
        {
            bool isValid = true;

            if (sender.Length != 11)
            {
                return !isValid;
            }

            foreach (char c in sender)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    return !isValid;
                }
            }

            // format is correct and true is returned
            return isValid;
        }

        private static bool IsCharacterLengthCorrect(string body)
        {
            bool isValid = true;

            if (body.Length > 140)
            {
                return !isValid;
            }

            return isValid;
        }
    }
}
