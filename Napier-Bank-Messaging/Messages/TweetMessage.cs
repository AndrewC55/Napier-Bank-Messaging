using System.Collections.Generic;
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

            mentionsList.WriteToMentionsList(header, GetFormattedListBody(body));
            hashtagList.WriteToHashtagsList(header, GetFormattedListBody(body));

            MessageHeader = header;
            MessageBody = textSpeakSanitiser.Sanatise(GetFormattedListBody(body));
        }

        public override bool FormatBody(string body)
        {
            List<string> listBody = GetFormattedListBody(body);
            return IsSenderCorrect(listBody[0]) && IsCharacterLengthCorrect(listBody[1]);
        }

        private bool IsSenderCorrect(string sender)
        {
            if (sender[0] != '@' || sender.Length > MaximumSenderCharacters)
            {
                MessageBody = "Sorry there was an error with your sender, your sender must begin with an '@' and be no more than 16 characters long";
                return false;
            }

            // format is correct and true is returned
            return true;
        }

        private bool IsCharacterLengthCorrect(string body)
        {
            if (body.Length > MaximumTweetCharacters)
            {
                MessageBody = "Sorry there was an error with your message body, your message must be no more than " + MaximumTweetCharacters + " characters long";
                return false;
            }

            return true;
        }
    }
}