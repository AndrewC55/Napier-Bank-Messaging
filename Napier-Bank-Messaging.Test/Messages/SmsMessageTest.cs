using Microsoft.VisualStudio.TestTools.UnitTesting;
using Napier_Bank_Messaging.Messages;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class SmsMessageTest
    {
        [TestMethod]
        public void DoesMessageHeaderWork()
        {
            Message message = new SmsMessage();
            message.MessageHeader = "S123456789";
            Assert.AreEqual(message.MessageHeader, "S123456789");
        }

        [TestMethod]
        public void DoesMessageBodyWork()
        {
            Message message = new SmsMessage();
            message.MessageBody = "blah";
            Assert.AreEqual(message.MessageBody, "blah");
        }

        [TestMethod]
        public void DoesFormatReturnFalseWhenCharacterCountIsExceeded()
        {
            Message message = new SmsMessage();
            string body = "12345678911\n" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww";
            Assert.IsFalse(message.FormatBody(body));
        }

        [TestMethod]
        public void DoesFormatReturnFalseWhenSenderIsWronglyFormatted()
        {
            Message message = new SmsMessage();
            string body = "123456789\n" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww";
            Assert.IsFalse(message.FormatBody(body));
        }

        [TestMethod]
        public void DoesFormatReturnTrueFormatIsCorrect()
        {
            Message message = new SmsMessage();
            string body = "12345678911\n" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww";
            Assert.IsFalse(message.FormatBody(body));
        }
    }
}