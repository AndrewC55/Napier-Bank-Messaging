using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public abstract void Sanatise(string body);

        public abstract bool Format(string body);
    }
}
