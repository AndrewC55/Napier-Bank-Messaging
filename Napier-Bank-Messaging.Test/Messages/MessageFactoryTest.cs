using Microsoft.VisualStudio.TestTools.UnitTesting;
using Napier_Bank_Messaging.Messages;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class MessageFactoryTest
    {
        [TestMethod]
        public void DoesReturnSmsClass()
        {
            MessageFactory messageFactory = new MessageFactory();
            Message message = messageFactory.Factory('S');

            message.MessageHeader = "S123456789";
            message.MessageBody = "Blah";
            
            Assert.AreEqual(message.MessageHeader, "S123456789");
            Assert.AreEqual(message.MessageBody, "Blah");
        }

        [TestMethod]
        public void DoesReturnTweetClass()
        {
            MessageFactory messageFactory = new MessageFactory();
            Message message = messageFactory.Factory('T');

            message.MessageHeader = "T123456789";
            message.MessageBody = "Blah";

            Assert.AreEqual(message.MessageHeader, "T123456789");
            Assert.AreEqual(message.MessageBody, "Blah");
        }

        [TestMethod]
        public void DoesReturnEmailClass()
        {
            MessageFactory messageFactory = new MessageFactory();
            Message message = messageFactory.Factory('E');

            message.MessageHeader = "E123456789";
            message.MessageBody = "Blah";

            Assert.AreEqual(message.MessageHeader, "E123456789");
            Assert.AreEqual(message.MessageBody, "Blah");
        }
    }
}