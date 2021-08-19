using System;
using System.Collections.Generic;
using Napier_Bank_Messaging.Tools;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Messages
{
    public class SmsMessage : Message
    {
        public override void Sanatise(string header, string body)
        {
            // create text speak sanitiser instance
            TextSpeakSanitiser textSpeakSanitiser = new TextSpeakSanitiser();

            // define label as header to be redisplayed
            MessageHeader = header;
            // define label as sanitised body to be redisplayed
            MessageBody = textSpeakSanitiser.Sanatise(GetFormattedListBody(body));
        }

        public override bool FormatBody(string body)
        {
            // get list of body with sections separated by enters
            List<string> listBody = GetFormattedListBody(body);
            // return boolean value of if sender and body are correct
            try
            {
                return IsSenderCorrect(listBody[0]) && IsCharacterLengthCorrect(listBody[1]);
            } catch (ArgumentOutOfRangeException)
            {
                MessageBody = "Sorry format of email is wrong, please try again";
                return false;
            }
        }

        private bool IsSenderCorrect(string sender)
        {
            // if sender(phone number) is not 11 digits long
            if (sender.Length != CharecterCountEnum.StandardTelephoneNumberLength)
            {
                // define body as error message
                MessageBody = "Sorry there was an error with your sender, your sender must be exactly " + CharecterCountEnum.StandardTelephoneNumberLength + " digits";
                return false;
            }

            // foreach through the sender
            foreach (char c in sender)
            {
                // if char is a digit
                if (!(c >= '0' && c <= '9'))
                {
                    // define body as error message
                    MessageBody = "Sorry there was an error with your sender, your sender must be all digits";
                    return false;
                }
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
            
            // body is under 140 characters so return true
            return true;
        }
    }
}
