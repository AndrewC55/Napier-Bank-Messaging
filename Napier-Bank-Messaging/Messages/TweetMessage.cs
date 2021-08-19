using System;
using System.Collections.Generic;
using Napier_Bank_Messaging.Tools;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Messages
{
    public class TweetMessage : Message
    {
        public override void Sanatise(string header, string body)
        {
            // create text speak sanitiser instance
            TextSpeakSanitiser textSpeakSanitiser = new TextSpeakSanitiser();
            // create mentions list instsnce
            MentionsList mentionsList = new MentionsList();
            // create hashtag list instance
            HashtagList hashtagList = new HashtagList();

            // write to mentions list
            mentionsList.WriteToMentionsList(header, GetFormattedListBody(body));
            // write to hashtags list
            hashtagList.WriteToHashtagsList(header, GetFormattedListBody(body));

            // define label as header to be redisplayed
            MessageHeader = header;
            // define label as sanitised body to be redisplayed
            MessageBody = textSpeakSanitiser.Sanatise(GetFormattedListBody(body));
        }

        public override bool FormatBody(string body)
        {
            // get list of body with sections separated by enters
            List<string> listBody = GetFormattedListBody(body);
            try
            {
                // return boolean value of if sender and body are correct
                return IsSenderCorrect(listBody[0]) && IsCharacterLengthCorrect(listBody[1]);
            } catch (ArgumentOutOfRangeException)
            {
                MessageBody = "Sorry format of email is wrong, please try again";
                return false;
            }
}

        private bool IsSenderCorrect(string sender)
        {
            // if first char is an '@' and if sender length is appropriate
            if (sender[0] != '@' || sender.Length > CharecterCountEnum.MaximumSenderCharacters)
            {
                // define body as error message
                MessageBody = "Sorry there was an error with your sender, your sender must begin with an '@' and be no more than "  + CharecterCountEnum.MaximumSenderCharacters + " characters long";
                return false;
            }

            // format is correct and true is returned
            return true;
        }

        private bool IsCharacterLengthCorrect(string body)
        {
            // if body is more than 140 characters
            if (body.Length > CharecterCountEnum.MaximumSmsAndTweetCharacters)
            {
                // define body as error message
                MessageBody = "Sorry there was an error with your message body, your message must be no more than " + CharecterCountEnum.MaximumSmsAndTweetCharacters + " characters long";
                return false;
            }

            // character length is ok and true is returned
            return true;
        }
    }
}