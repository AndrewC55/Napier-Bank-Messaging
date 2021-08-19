using System;
using System.Collections.Generic;
using System.Linq;
using Napier_Bank_Messaging.Validators;

namespace Napier_Bank_Messaging.Messages
{
    public abstract class Message
    {
        private string _messageHeader, _messageBody;

        public string MessageHeader
        {
            get => _messageHeader;
            set => _messageHeader = value;
        }

        public string MessageBody
        {
            get => _messageBody;
            set => _messageBody = value;
        }
        public List<string> GetFormattedListBody(string body)
        {
            List<string> listBody = body.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            return listBody;
        }

        public bool FormatHeader(string header)
        {
            HeaderValidator headerValidator = new HeaderValidator();

            if (!headerValidator.IsHeaderLengthValid(header))
            {
                // if length of message ID is wrong then message is changed to error message
                MessageHeader = "Sorry, message ID must be 10 characters long, please try again";
            }
            else if (!headerValidator.isMessageTypeValid(header))
            {
                // if message ID doesn't contain a message type then message is changed to error message
                MessageHeader = "Sorry, message ID must constain a message type ('S' = 'SMS', 'E' = 'Email', 'T' = 'Tweet')";
            }
            else if (!headerValidator.isMessageFormatCorrect(header))
            {
                // if message ID is wrongly formatted then message is changed to error message
                MessageHeader = "Sorry, message must be in the format of message type followed by 9 numbers (e.g. E123456789)";
            }

            return true;
        }

        public abstract void Sanatise(string header, string body);

        public abstract bool FormatBody(string body);
    }
}
