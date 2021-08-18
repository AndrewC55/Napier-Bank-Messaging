using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Napier_Bank_Messaging.Messages
{
    public class EmailMessage : Message
    {
        public override void Sanatise(string header, string body)
        {
            MessageHeader = header;
            MessageBody = body;
        }

        public override bool Format(string body)
        {
            List<string> listBody = GetFormattedListBody(body);
            return IsSenderCorrect(listBody[0]) && IsSubjectCorrect(listBody[1]) && IsCharacterLengthCorrect(listBody[2]);
        }

        private bool IsSenderCorrect(string body)
        {
            bool isValid = true;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(body);

            return match.Success;
        }

        private bool IsSubjectCorrect(string body)
        {
            bool isValid = true;

            if (body.Length > 20)
            {
                return !isValid;
            }

            return isValid;
        }

        private static bool IsCharacterLengthCorrect(string body)
        {
            bool isValid = true;

            if (body.Length > 1028)
            {
                return !isValid;
            }

            return isValid;
        }
    }
}
