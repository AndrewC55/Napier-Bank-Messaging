﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Napier_Bank_Messaging.Tools;
using Napier_Bank_Messaging.Messages;
using System.IO;
using System.Linq;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class MentionsListTest
    {
        private const string FilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\MentionsList.txt";
        [TestMethod]
        public void DoesWriteToFileCorrectlyWriteToFile()
        {
            List<string> body = new List<string>();
            MentionsList mentionsList = new MentionsList();
            body.Add("@andrew");
            body.Add("add @test");

            mentionsList.WriteToMentionsList(body);
            Assert.AreEqual(File.ReadLines(FilePath).Last(), "@test");
        }
    }
}