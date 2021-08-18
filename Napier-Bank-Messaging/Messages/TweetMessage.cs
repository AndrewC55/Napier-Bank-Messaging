using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Napier_Bank_Messaging.Tools;

namespace Napier_Bank_Messaging.Messages
{
    public class TweetMessage : Message
    {
        const int MaximumSenderCharacters = 16;
        const int MaximumTweetCharacters = 140;

        public override void Sanatise(string header, string body)
        {
            TextSpeakSanitiser textSpeakSanitiser = new TextSpeakSanitiser();
            MentionsList mentionsList = new MentionsList();
            HashtagList hashtagList = new HashtagList();

            mentionsList.WriteToMentionsList(GetFormattedListBody(body));
            hashtagList.WriteToHashtagsList(GetFormattedListBody(body));

            MessageHeader = header;
            MessageBody = textSpeakSanitiser.Sanatise(GetFormattedListBody(body));
        }

        public override bool Format(string body)
        {
            List<string> listBody = GetFormattedListBody(body);
            return IsSenderCorrect(listBody[0]) && IsCharacterLengthCorrect(listBody[1]);
        }

        private bool IsSenderCorrect(string sender)
        {
            if (sender[0] != '@' || sender.Length > MaximumSenderCharacters)
            {
                return false;
            }

            // format is correct and true is returned
            return true;
        }

        private static bool IsCharacterLengthCorrect(string body)
        {
            return body.Length > MaximumTweetCharacters ? false : true;
        }
    }
}