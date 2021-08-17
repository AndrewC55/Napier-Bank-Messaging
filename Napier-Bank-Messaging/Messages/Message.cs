using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napier_Bank_Messaging.Messages
{
    public class Message
    {
        public string _messageHeader, _messageBody;

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

        //public abstract void Sanatise();
        //public abstract void Format();
    }
}
