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

        public override bool FormatBody(string body)
        {
            List<string> listBody = GetFormattedListBody(body);
            return IsSenderCorrect(listBody[0]) && IsCharacterLengthCorrect(listBody[1]);
        }

        private bool IsSenderCorrect(string sender)
        {
            if (sender.Length != StandardTelephoneNumberLength)
            {
                MessageBody = "Sorry there was an error with your sender, your sender must be exactly 11 digits";
                return false;
            }

            foreach (char c in sender)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    MessageBody = "Sorry there was an error with your sender, your sender must be all digits";
                    return false;
                }
            }

            // format is correct and true is returned
            return true;
        }

        private bool IsCharacterLengthCorrect(string body)
        {
            if (body.Length > MaximumSMSCharacters)
            {
                MessageBody = "Sorry there was an error with your message body, your message must be no more than 140 characters long";
                return false;
            }
            
            return true;
        }
    }
}
