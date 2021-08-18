using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Napier_Bank_Messaging.Tools
{
    public class UrlSanitiser
    {
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
                    continue;
                }

                sanitisedBody = sanitisedBody + " " + message;
            }

            return sanitisedBody;
        }
    }
}
