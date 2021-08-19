using System.Collections.Generic;
using System.Text.RegularExpressions;
using Napier_Bank_Messaging.Tools;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Messages
{
    public class EmailMessage : Message
    {
        public override void Sanatise(string header, string body)
        {
            // create url sanitiser instance
            UrlSanitiser urlSanitiser = new UrlSanitiser();
            // create sir report instance
            SirList sirList = new SirList();
            // get formatted body
            List<string> listBody = GetFormattedListBody(body);

            // if email is a significant incident report
            if (IsEmailSir(listBody[1]))
            {
                // write sir to sir list
                sirList.WriteToSirList(listBody[0], listBody[2], listBody[3]);
            }

            // define label as header to be redisplayed
            MessageHeader = header;
            // define label as sanitised body to be redisplayed
            MessageBody = urlSanitiser.Sanatise(header, listBody, IsEmailSir(listBody[1]));
        }

        // inherited format body
        public override bool FormatBody(string body)
        {
            List<string> listBody = GetFormattedListBody(body);
            if (IsEmailSir(listBody[1]) && listBody.Count == 5)
            {
                return IsSenderCorrect(listBody[0]) && IsSubjectLengthCorrect(listBody[1]) && IsSortCodeCorrect(listBody[2]) && IsNatureOfIncidentCorrect(listBody[3]) && IsCharacterLengthCorrect(listBody[4]);
            }
            return IsSenderCorrect(listBody[0]) && IsSubjectLengthCorrect(listBody[1]) && IsCharacterLengthCorrect(listBody[2]);
        }

        // fucntion to check if email is sir
        private bool IsEmailSir(string subject)
        {
            // substring to see get first 3 chars
            subject = subject.Substring(0, 3);
            // if subject contains sir then return true
            return subject == "SIR" ? true : false;
        }

        // 
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
            if (subject.Length > CharecterCountEnum.MaximumSubjectCharacters)
            {
                MessageBody = "Sorry there was an error with your message body, your subject must be no more than " + CharecterCountEnum.MaximumSubjectCharacters + " characters long";
                return false;
            }
            return subject.Length >CharecterCountEnum.MaximumSubjectCharacters ? false : true;
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
            if (body.Length > CharecterCountEnum.MaximumEmailCharacters)
            {
                MessageBody = "Sorry there was an error with your message body, your message must be no more than " + CharecterCountEnum.MaximumEmailCharacters +  " characters long";
                return false;
            }

            return true;
        }
    }
}
