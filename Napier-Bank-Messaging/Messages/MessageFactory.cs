namespace Napier_Bank_Messaging.Messages
{
    public class MessageFactory
    {
        // define string class message type variable
        private string _messageType;

        // getter and setter for message type
        public string MessageType
        {
            get => _messageType;
            set => _messageType = value;
        }

        // factory to return appropriate class
        public Message Factory(char type)
        {
            return type switch
            {
                'S' => new SmsMessage(),
                'E' => new EmailMessage(),
                'T' => new TweetMessage()
            };
        }
    }
}
