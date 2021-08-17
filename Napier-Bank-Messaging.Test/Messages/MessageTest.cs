using Microsoft.VisualStudio.TestTools.UnitTesting;
using Napier_Bank_Messaging.Messages;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class MessageTest
    {
        [TestMethod]
        public void DoesMessageHeaderWork()
        {
            Message message= new Message();
            message.MessageHeader = "E123456789";
            Assert.AreEqual(message.MessageHeader, "E123456789");
        }

        [TestMethod]
        public void DoesMessageBodyWork()
        {
            Message message = new Message();
            message.MessageBody = "blah";
            Assert.AreEqual(message.MessageBody, "blah");
        }
    }
}