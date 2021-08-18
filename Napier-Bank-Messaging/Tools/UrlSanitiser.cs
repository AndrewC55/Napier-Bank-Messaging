using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Napier_Bank_Messaging.Tools
{
    public class UrlSanitiser
    {
        private const string FilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\QuarantineList.txt";

        public string Sanatise(List<string> body)
        {
            List<string> messageBody = body[2].Split(" ").ToList();
            string sanitisedBody = body[0] + "\n" + body[1] + "\n";
            Regex regex = new Regex(@"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$");

            foreach (string message in messageBody)
            {
                if (regex.IsMatch(message))
                {
                    sanitisedBody = sanitisedBody + " <URL Quarantined>";
                    WriteToQuarantineList(message);
                    continue;
                }

                sanitisedBody = sanitisedBody + " " + message;
            }

            return sanitisedBody;
        }

        private void WriteToQuarantineList(string url)
        {
            File.AppendAllText(FilePath, url);
        }
    }
}
