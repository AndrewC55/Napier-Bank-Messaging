using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Tools
{
    public class UrlSanitiser
    {
        // sanitise function to quarantine the url
        public string Sanatise(string header, List<string> body, bool isSir)
        {
            // check if email is sir or not and assign proper string for message body if so
            string mainMessage = isSir ? body[4] : body[2];
            // split all message body into single body
            List<string> messageBody = mainMessage.Split(" ").ToList();
            // build return string to start
            string sanitisedBody = body[0] + "\n" + body[1] + "\n";
            // regex patter to find url
            Regex regex = new Regex(@"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$");

            // if email is sir
            if (isSir)
            {
                // then add sort code and nature of incident to start of return string
                sanitisedBody = sanitisedBody + body[2] + "\n" + body[3] + "\n";
            }

            // foreach through message body
            foreach (string message in messageBody)
            {
                // if word is a url link
                if (regex.IsMatch(message))
                {
                    // replace url link with quarantined text
                    sanitisedBody = sanitisedBody + " <URL Quarantined>";
                    // write url link to quarantine list
                    WriteToQuarantineList(header, message);
                    // continue through the loop
                    continue;
                }

                // if word is not a link then add it to return string
                sanitisedBody = sanitisedBody + " " + message;
            }

            // return sanitised string
            return sanitisedBody;
        }

        // function to write all url links to quarantine list
        private void WriteToQuarantineList(string header, string url)
        {
            // append message header and url link to file
            File.AppendAllText(FilePathEnum.QuarantineListFilePath, header + ": " + url + "\n");
        }
    }
}
