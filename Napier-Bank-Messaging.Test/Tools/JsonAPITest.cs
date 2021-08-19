using Microsoft.VisualStudio.TestTools.UnitTesting;
using Napier_Bank_Messaging.Tools;
using Napier_Bank_Messaging.Messages;
using System.IO;
using System.Linq;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class JsonAPITest
    {
        [TestMethod]
        public void DoesSanitiseReturnCorrectlyFormattedBodyForSms()
        {
            JsonAPI jsonAPI = new JsonAPI();
            Message message = new SmsMessage();
            message.MessageHeader = "S123456789";
            message.MessageBody = "12345678911\n This is an SMS message";

            jsonAPI.ToJson(message);
            Assert.AreEqual(File.ReadLines(FilePathEnum.JsonFilePath).Last(), "{\"MessageHeader\":\"S123456789\",\"MessageBody\":\"12345678911\\n This is an SMS message\"}");
        }
    }
}
