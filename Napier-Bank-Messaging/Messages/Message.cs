using System;
using System.Collections.Generic;
using System.Linq;
using Napier_Bank_Messaging.Validators;

namespace Napier_Bank_Messaging.Messages
{
    public abstract class Message
    {
        // define string class variables for message header and message body
        private string _messageHeader, _messageBody;

        // getter and setter for message header
        public string MessageHeader
        {
            get => _messageHeader;
            set => _messageHeader = value;
        }

        // getter and setter for message
        public string MessageBody
        {
            get => _messageBody;
            set => _messageBody = value;
        }

        // get formatted body by splitting body into a list by enters
        public List<string> GetFormattedListBody(string body)
        {
            // define list by new line from inputted text
            List<string> listBody = body.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            // return list
            return listBody;
        }

        // function to format header
        public bool FormatHeader(string header)
        {
            // define new header validator instance
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

            // if all conditions pass then header is correct format
            return true;
        }

        // make abstract void to be overridden by child class
        public abstract void Sanatise(string header, string body);

        // make abstract void to be overridden by child class
        public abstract bool FormatBody(string body);
    }
}
