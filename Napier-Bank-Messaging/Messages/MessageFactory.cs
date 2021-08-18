using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napier_Bank_Messaging.Messages
{
    public class MessageFactory
    {
        private string _messageType;

        public string MessageType
        {
            get => _messageType;
            set => _messageType = value;
        }

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
