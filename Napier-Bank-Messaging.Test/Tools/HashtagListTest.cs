using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Napier_Bank_Messaging.Tools;
using Napier_Bank_Messaging.Messages;
using System.IO;
using System.Linq;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class HashtagListTest
    {
        private const string FilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\HashtagList.txt";
        [TestMethod]
        public void DoesWriteToFileCorrectlyWriteToFile()
        {
            List<string> body = new List<string>();
            HashtagList hashtagList = new HashtagList();
            string header = "T123456789";
            body.Add("@andrew");
            body.Add("add #test");

            hashtagList.WriteToHashtagsList(header, body);
            Assert.AreEqual(File.ReadLines(FilePath).Last(), "T123456789: #test");
        }
    }
}
