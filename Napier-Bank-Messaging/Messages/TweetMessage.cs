using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napier_Bank_Messaging.Messages
{
    public class TweetMessage : Message
    {
        public override void Sanatise(string header, string body)
        {
            MessageHeader = header;
            MessageBody = body;
        }

        public override bool Format(string body)
        {
            List<string> listBody = GetFormattedListBody(body);
            return IsSenderCorrect(listBody[0]) && IsCharacterLengthCorrect(listBody[1]);
        }

        private bool IsSenderCorrect(string body)
        {
            bool isValid = true;

            if (body[0] != '@' || body.Length > 16)
            {
                return !isValid;
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