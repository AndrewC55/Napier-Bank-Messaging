using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Validators
{
    public class HeaderValidator
    {
        // message type const for SMS
        const char Sms = 'S';
        // message type const for Email
        const char EMAIL = 'E';
        // message type const for Tweet
        const char Tweet = 'T';

        // function used for checking length of message ID
        public bool IsHeaderLengthValid(string header)
        {
            // if header length is correct then return true else false
            return header.Length == CharecterCountEnum.MaximumHeaderCharacters ? true : false;
        }

        // function used for checking type of message
        public bool isMessageTypeValid(string header)
        {
            // return value
            bool isValid = true;
            if ((header[0] != Sms) && (header[0] != EMAIL) && (header[0] != Tweet))
            {
                // if first char of message ID is not 'S', 'E' or 'T' return value is set to false and returned
                return !isValid;
            }

            // first char is a message type and true is returned
            return isValid;
        }

        public bool isMessageFormatCorrect(string header)
        {
            // return value
            bool isValid = true;
            // remove first char of header as that is already confirmed to be a message type
            header = header.Remove(0, 1);

            // now foreach through each char
            foreach (char c in header)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    // if char of message ID is not numeric, return value is set to false and returned
                    return !isValid;
                }
            }

            // format is correct and true is returned
            return isValid;
        }
    }
}
