using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Napier_Bank_Messaging.Tools;
using System.IO;
using System.Linq;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class MentionsListTest
    {
        [TestMethod]
        public void DoesWriteToFileCorrectlyWriteToFile()
        {
            List<string> body = new List<string>();
            MentionsList mentionsList = new MentionsList();
            string header = "T123456789";
            body.Add("@andrew");
            body.Add("add @test");

            mentionsList.WriteToMentionsList(header, body);
            Assert.AreEqual(File.ReadLines(FilePathEnum.MentionsListFilePath).Last(), "T123456789: @test");
        }
    }
}
