using System.Collections.Generic;
using System.Linq;
using System.IO;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Tools
{
    public class MentionsList
    {
        public void WriteToMentionsList(string header, List<string> body)
        {
            List<string> messageBody = body[1].Split(" ").ToList();

            foreach (string message in messageBody)
            {
                if (message[0] == '@')
                {
                    File.AppendAllText(FilePathEnum.MentionsListFilePath, header + ": " + message + "\n");
                }
            }
        }
    }
}
