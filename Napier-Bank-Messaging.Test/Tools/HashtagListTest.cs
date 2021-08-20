using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Napier_Bank_Messaging.Tools;
using System.IO;
using System.Linq;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class HashtagListTest
    {
        [TestMethod]
        public void DoesWriteToFileCorrectlyWriteToFile()
        {
            List<string> body = new List<string>();
            HashtagList hashtagList = new HashtagList();
            string header = "T123456789";
            body.Add("@andrew");
            body.Add("add #test");

            hashtagList.WriteToHashtagsList(header, body);
            Assert.AreEqual(File.ReadLines(FilePathEnum.HashtagListFilePath).Last(), "T123456789: #test");
        }
    }
}
