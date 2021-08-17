﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Napier_Bank_Messaging.Messages;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class MessageFactoryTest
    {
        [TestMethod]
        public void DoesReturnMessageClass()
        {
            MessageFactory messageFactory = new MessageFactory();
            Message message = messageFactory.Factory();

            message.MessageHeader = "E123456789";
            message.MessageBody = "Blah";
            
            Assert.AreEqual(message.MessageHeader, "E123456789");
            Assert.AreEqual(message.MessageBody, "Blah");
        }
    }
}