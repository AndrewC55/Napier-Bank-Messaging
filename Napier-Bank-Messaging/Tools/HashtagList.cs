using System.Collections.Generic;
using System.Linq;
using System.IO;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Tools
{
    public class HashtagList
    {
        // function to write what's trending to file
        public void WriteToHashtagsList(string header, List<string> body)
        {
            // create string list to turn bodies into single words
            List<string> messageBody = body[1].Split(" ").ToList();

            // foreach through message body
            foreach (string message in messageBody)
            {
                // if word is a hashtagged word then write to hashtag list
                if (message[0] == '#')
                {
                    File.AppendAllText(FilePathEnum.HashtagListFilePath, header + ": " + message + "\n");
                }
            }
        }
    }
}
