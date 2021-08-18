using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using Napier_Bank_Messaging.Tools;

namespace Napier_Bank_Messaging.Messages
{
    public class EmailMessage : Message
    {
        private const int MaximumEmailCharacters = 1028;
        private const int MaximumSubjectCharacters = 20;

        public override void Sanatise(string header, string body)
        {
            UrlSanitiser urlSanitiser = new UrlSanitiser();
            MessageHeader = header;
            MessageBody = urlSanitiser.Sanatise(GetFormattedListBody(body));
        }

        public override bool Format(string body)
        {
            List<string> listBody = GetFormattedListBody(body);
            return IsSenderCorrect(listBody[0]) && IsSubjectLengthCorrect(listBody[1]) && IsCharacterLengthCorrect(listBody[2]);
        }

        private bool IsSenderCorrect(string body)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(body);
        }

        private bool IsSubjectLengthCorrect(string subject)
        {
            return subject.Length > MaximumSubjectCharacters ? false : true;
        }

        private static bool IsCharacterLengthCorrect(string body)
        {
            return body.Length > MaximumEmailCharacters ? false : true;
        }
    }
}
