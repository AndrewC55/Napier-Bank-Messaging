using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Napier_Bank_Messaging.Tools
{
    public class MentionsList
    {
        private const string FilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\MentionsList.txt";

        public void WriteToMentionsList(List<string> body)
        {
            List<string> messageBody = body[1].Split(" ").ToList();

            foreach (string message in messageBody)
            {
                if (message[0] == '@')
                {
                    File.AppendAllText(FilePath, message + "\n");
                }
            }
        }
    }
}
