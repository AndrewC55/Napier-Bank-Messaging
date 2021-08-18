using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Napier_Bank_Messaging.Tools;
using Napier_Bank_Messaging.Messages;
using System.IO;
using System.Linq;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class JsonAPITest
    {
        private const string FilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\JsonFile.txt";
        [TestMethod]
        public void DoesSanitiseReturnCorrectlyFormattedBodyForSms()
        {
            JsonAPI jsonAPI = new JsonAPI();
            Message message = new SmsMessage();
            message.MessageHeader = "S123456789";
            message.MessageBody = "12345678911\n This is an SMS message";

            jsonAPI.ToJson(message);
            Assert.AreEqual(File.ReadLines(FilePath).Last(), "{\"MessageHeader\":\"S123456789\",\"MessageBody\":\"12345678911\\n This is an SMS message\"}");
        }
    }
}
