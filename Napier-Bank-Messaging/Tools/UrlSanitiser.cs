using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Tools
{
    public class UrlSanitiser
    {
        public string Sanatise(string header, List<string> body, bool isSir)
        {
            string mainMessage = isSir ? body[4] : body[2];
            List<string> messageBody = mainMessage.Split(" ").ToList();
            string sanitisedBody = body[0] + "\n" + body[1] + "\n";
            Regex regex = new Regex(@"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$");

            if (isSir)
            {
                sanitisedBody = sanitisedBody + body[2] + "\n" + body[3] + "\n";
            }

            foreach (string message in messageBody)
            {
                if (regex.IsMatch(message))
                {
                    sanitisedBody = sanitisedBody + " <URL Quarantined>";
                    WriteToQuarantineList(header, message);
                    continue;
                }

                sanitisedBody = sanitisedBody + " " + message;
            }

            return sanitisedBody;
        }

        private void WriteToQuarantineList(string header, string url)
        {
            File.AppendAllText(FilePathEnum.QuarantineListFilePath, header + ": " + url + "\n");
        }
    }
}
