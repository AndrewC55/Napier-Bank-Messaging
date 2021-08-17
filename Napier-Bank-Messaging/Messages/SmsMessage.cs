using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napier_Bank_Messaging.Messages
{
    public class SmsMessage : Message
    {
        public override void Sanatise(string body)
        {
        }

        public override bool Format(string body)
        {
            return IsSenderCorrect(body) || IsCharacterLengthCorrect(body);
        }

        private bool IsSenderCorrect(string body)
        {
            bool isValid = true;

            // now foreach through each char
            for (int i = 0; i < 11; i++)
            {
                if (!(body[i] >= '0' && body[i] <= 9))
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
            body = body.Remove(0, 11);

            if (body.Length > 140)
            {
                return !isValid;
            }

            return isValid;
        }
    }
}
