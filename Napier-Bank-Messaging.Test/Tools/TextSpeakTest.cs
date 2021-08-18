using Microsoft.VisualStudio.TestTools.UnitTesting;
using Napier_Bank_Messaging.Tools;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class TextSpeakTest
    {
        [TestMethod]
        public void DoesAbbreviationWork()
        {
            TextSpeak textSpeak = new TextSpeak();
            textSpeak.Abbreviation= "AAP";
            Assert.AreEqual(textSpeak.Abbreviation, "AAP");
        }

        [TestMethod]
        public void DoesPhraseWork()
        {
            TextSpeak textSpeak = new TextSpeak();
            textSpeak.Abbreviation = "Always a pleasure";
            Assert.AreEqual(textSpeak.Abbreviation, "Always a pleasure");
        }
    }
}
