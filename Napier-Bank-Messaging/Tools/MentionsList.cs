using System.Collections.Generic;
using System.Linq;
using System.IO;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Tools
{
    public class MentionsList
    {
        // function to write to mentions list
        public void WriteToMentionsList(string header, List<string> body)
        {
            // create list based on values of tweet body
            List<string> messageBody = body[1].Split(" ").ToList();

            // foreach through list
            foreach (string message in messageBody)
            {
                // if first character of word is @ then it's a mention so muct be writtent to file
                if (message[0] == '@')
                {
                    File.AppendAllText(FilePathEnum.MentionsListFilePath, header + ": " + message + "\n");
                }
            }
        }
    }
}
