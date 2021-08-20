using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Napier_Bank_Messaging.Tools;
using System.IO;
using System.Linq;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class SirListTest
    {
        [TestMethod]
        public void DoesWriteToFileCorrectlyWriteToFile()
        {
            SirList sirList= new SirList();
            string header = "E123456789", sortCode = "Sort Code: 99-99-99", incident = "Nature of Incident: Theft";

            sirList.WriteToSirList(header, sortCode, incident);
            Assert.AreEqual(File.ReadLines(FilePathEnum.SirListFilePath).Last(), "E123456789: Sort Code: 99-99-99, Nature of Incident: Theft");
        }
    }
}
