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
        const int StandardTelephoneNumberLength = 11;
        const int MaximumSMSCharacters = 140;

        public override void Sanatise(string header, string body)
        {
            TextSpeakSanitiser textSpeakSanitiser = new TextSpeakSanitiser();
            MessageHeader = header;
            MessageBody = textSpeakSanitiser.Sanatise(GetFormattedListBody(body));
        }

        public override bool Format(string body)
        {
            List<string> listBody = GetFormattedListBody(body);
            return IsSenderCorrect(listBody[0]) && IsCharacterLengthCorrect(listBody[1]);
        }

        private bool IsSenderCorrect(string sender)
        {
            if (sender.Length != StandardTelephoneNumberLength)
            {
                return false;
            }

            foreach (char c in sender)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    return false;
                }
            }

            // format is correct and true is returned
            return true;
        }

        private static bool IsCharacterLengthCorrect(string body)
        {
            return body.Length > MaximumSMSCharacters ? false : true;
        }
    }
}
