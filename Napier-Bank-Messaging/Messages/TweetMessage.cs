using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napier_Bank_Messaging.Messages
{
    class TweetMessage : Message
    {
        public override void Sanatise(string body)
        {
        }

        public override bool Format(string body)
        {
            List<string> listBody = body.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            return IsSenderCorrect(listBody[0]) && IsCharacterLengthCorrect(listBody[1]);
        }

        private bool IsSenderCorrect(string body)
        {
            bool isValid = true;

            if (body[0] != '@')
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