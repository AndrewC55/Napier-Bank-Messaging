using System.Collections.Generic;
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
                sirList.WriteToSirList(listBody[0], listBody[2], listBody[3]);
            }

            MessageHeader = header;
            MessageBody = urlSanitiser.Sanatise(header, listBody, IsEmailSir(listBody[1]));
        }

        public override bool FormatBody(string body)
        {
            List<string> listBody = GetFormattedListBody(body);
            if (IsEmailSir(listBody[1]) && listBody.Count == 5)
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

        private bool IsSenderCorrect(string sender)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.IsMatch(sender))
            {
                MessageBody = "Sorry there was an error with your message body, your Sender was formatted wrong (e.g johndoe@email.com)";
                return false;
            }

            return true;
        }

        private bool IsSubjectLengthCorrect(string subject)
        {
            if (subject.Length > MaximumSubjectCharacters)
            {
                MessageBody = "Sorry there was an error with your message body, your subject must be no more than " + MaximumSubjectCharacters + " characters long";
                return false;
            }
            return subject.Length > MaximumSubjectCharacters ? false : true;
        }

        private bool IsSortCodeCorrect(string sortCode)
        {
            Regex regex = new Regex(@"/(\d{2}-?){2}\d{2}/");
            if (!(sortCode.Substring(0, 10) == "Sort Code:"))
            {
                MessageBody = "Sorry there was an error with your message body, your Sort code was formatted wrong (e.g Sort Code: 99-99-99)";
                return false;
            }

            return true;
        }

        private bool IsNatureOfIncidentCorrect(string natureOfIncident)
        {
            SirList sirList = new SirList();
            if (natureOfIncident.Substring(0, 18) != "Nature of Incident")
            {
                MessageBody = "Sorry there was an error with your message body, your Nature of Incident was formatted wrong (e.g Nature of Incident: Theft)";
                return false;
            }

            foreach (string incident in sirList.GetNatureOfIncidentsValues())
            {
                if (incident == natureOfIncident.Substring(20))
                {
                    return true;
                }
            }

            MessageBody = "Sorry there was an error with your message body, your Nature of Incident was formatted wrong (e.g Nature of Incident: Theft)";
            return false;
        }

        private bool IsCharacterLengthCorrect(string body)
        {
            if (body.Length > MaximumEmailCharacters)
            {
                MessageBody = "Sorry there was an error with your message body, your message must be no more than " + MaximumEmailCharacters +  " characters long";
                return false;
            }

            return true;
        }
    }
}
