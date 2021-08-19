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
            SirList sirList = new SirList();
            List<string> listBody = GetFormattedListBody(body);

            if (IsEmailSir(listBody[1]))
            {
                sirList.WriteToSirList(listBody[2], listBody[3]);
            }

            MessageHeader = header;
            MessageBody = urlSanitiser.Sanatise(listBody, IsEmailSir(listBody[1]));
        }

        public override bool FormatBody(string body)
        {
            List<string> listBody = GetFormattedListBody(body);
            if (IsEmailSir(listBody[1]))
            {
                return IsSenderCorrect(listBody[0]) && IsSubjectLengthCorrect(listBody[1]) && IsSortCodeCorrect(listBody[2]) && IsNatureOfIncidentCorrect(listBody[3]) && IsCharacterLengthCorrect(listBody[4]);
            }
            return IsSenderCorrect(listBody[0]) && IsSubjectLengthCorrect(listBody[1]) && IsCharacterLengthCorrect(listBody[2]);
        }

        private bool IsEmailSir(string subject)
        {
            subject = subject.Substring(0, 3);
            return subject == "SIR" ? true : false;
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

        private bool IsSortCodeCorrect(string sortCode)
        {
            MessageHeader = "sort";
            Regex regex = new Regex(@"/(\d{2}-?){2}\d{2}/");
            if ((sortCode.Substring(0, 10) == "Sort Code:"))
            {
                return true;
            }

            return false;
        }

        private bool IsNatureOfIncidentCorrect(string natureOfIncident)
        {
            SirList sirList = new SirList();
            if (natureOfIncident.Substring(0, 18) != "Nature of Incident")
            {
                return false;
            }

            foreach (string incident in sirList.GetNatureOfIncidentsValues())
            {
                if (incident == natureOfIncident.Substring(20))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsCharacterLengthCorrect(string body)
        {
            return body.Length > MaximumEmailCharacters ? false : true;
        }
    }
}
