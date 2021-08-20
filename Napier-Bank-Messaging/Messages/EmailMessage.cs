using System;
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
            try
            {
                if (IsEmailSir(listBody[1]) && listBody.Count == 5)
                {
                    return IsSenderCorrect(listBody[0]) && IsSubjectLengthCorrect(listBody[1]) && IsSortCodeCorrect(listBody[2]) && IsNatureOfIncidentCorrect(listBody[3]) && IsCharacterLengthCorrect(listBody[4]);
                }
                return IsSenderCorrect(listBody[0]) && IsSubjectLengthCorrect(listBody[1]) && IsCharacterLengthCorrect(listBody[2]);
            } catch (ArgumentOutOfRangeException)
            {
                // define body as error message
                MessageBody = "Sorry format of email is wrong, please try again";
                return false;
            }
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
            // define regex pattern for email
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            // if sender is not in email format
            if (!regex.IsMatch(sender))
            {
                // define body as error message
                MessageBody = "Sorry there was an error with your message body, your Sender was formatted wrong (e.g johndoe@email.com)";
                return false;
            }

            // patter is correct
            return true;
        }

        private bool IsSubjectLengthCorrect(string subject)
        {
            // if subject is longer than maximum allowed characters
            if (subject.Length > CharecterCountEnum.MaximumSubjectCharacters)
            {
                // define body as error message
                MessageBody = "Sorry there was an error with your message body, your subject must be no more than " + CharecterCountEnum.MaximumSubjectCharacters + " characters long";
                return false;
            }

            // character count is in range
            return true;
        }

        private bool IsSortCodeCorrect(string sortCode)
        {
            Regex regex = new Regex(@"/(\d{2}-?){2}\d{2}/");
            // if sort code starts with sort code string
            if (!(sortCode.Substring(0, 10) == "Sort Code:"))
            {
                // define body as error message
                MessageBody = "Sorry there was an error with your message body, your Sort code was formatted wrong (e.g Sort Code: 99-99-99)";
                return false;
            }

            // sort code is correct format
            return true;
        }

        private bool IsNatureOfIncidentCorrect(string natureOfIncident)
        {
            // create sir list instance
            SirList sirList = new SirList();
            // if nature of incident code starts with nature of incident string
            if (natureOfIncident.Substring(0, 18) != "Nature of Incident")
            {
                // define body as error message
                MessageBody = "Sorry there was an error with your message body, your Nature of Incident was formatted wrong (e.g Nature of Incident: Theft)";
                return false;
            }

            // foreach through every incident type
            foreach (string incident in sirList.GetNatureOfIncidentsValues())
            {
                // if incident type matches nature of incident
                if (incident == natureOfIncident.Substring(20))
                {
                    // break loop as match has been found
                    return true;
                }
            }

            // define body as error message
            MessageBody = "Sorry there was an error with your message body, your Nature of Incident was formatted wrong (e.g Nature of Incident: Theft)";
            return false;
        }

        private bool IsCharacterLengthCorrect(string body)
        {
            // if message text if more than 1028 characters long
            if (body.Length > CharecterCountEnum.MaximumEmailCharacters)
            {
                // define body as error message
                MessageBody = "Sorry there was an error with your message body, your message must be no more than " + CharecterCountEnum.MaximumEmailCharacters +  " characters long";
                return false;
            }

            // character count is in range
            return true;
        }
    }
}
