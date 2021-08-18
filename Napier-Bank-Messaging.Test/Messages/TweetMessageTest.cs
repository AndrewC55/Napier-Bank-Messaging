using Microsoft.VisualStudio.TestTools.UnitTesting;
using Napier_Bank_Messaging.Messages;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class TweetMessageTest
    {
        [TestMethod]
        public void DoesMessageHeaderWork()
        {
            Message message = new TweetMessage();
            message.MessageHeader = "S123456789";
            Assert.AreEqual(message.MessageHeader, "S123456789");
        }

        [TestMethod]
        public void DoesMessageBodyWork()
        {
            Message message = new TweetMessage();
            message.MessageBody = "blah";
            Assert.AreEqual(message.MessageBody, "blah");
        }

        [TestMethod]
        public void DoesFormatReturnFalseWhenCharacterCountIsExceeded()
        {
            Message message = new TweetMessage();
            string exceededChars = "@andrew\n" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww";
            Assert.IsFalse(message.Format(exceededChars));
        }

        [TestMethod]
        public void DoesFormatReturnFalseWhenSenderIsWronglyFormatted()
        {
            Message message = new TweetMessage();
            string exceededChars = "andrew\n" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww";
            Assert.IsFalse(message.Format(exceededChars));
        }

        [TestMethod]
        public void DoesFormatReturnTrueFormatIsCorrect()
        {
            Message message = new TweetMessage();
            string exceededChars = "@andrew\n" +
                "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww";
            Assert.IsFalse(message.Format(exceededChars));
        }
    }
}
