﻿using System;
using System.Collections.Generic;
using System.Linq;

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

        public abstract void Sanatise(string header, string body);

        public abstract bool Format(string body);
    }
}
