using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Napier_Bank_Messaging.Tools;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class TextSpeakSanitiserTest
    {
        [TestMethod]
        public void DoesSanitiseReturnCorrectlyFormattedBodyForTweet()
        {
            TextSpeakSanitiser textSpeakSanitiser = new TextSpeakSanitiser();
            List<string> body = new List<string>();
            body.Add("@andrewTest");
            body.Add("This is a tweet");
            
            Assert.AreEqual(textSpeakSanitiser.Sanatise(body), "@andrewTest\n This is a tweet" );
        }

        [TestMethod]
        public void DoesSanitiseReturnCorrectlyFormattedBodyForTweetWithTextSpeak()
        {
            TextSpeakSanitiser textSpeakSanitiser = new TextSpeakSanitiser();
            List<string> body = new List<string>();
            body.Add("@andrewTest");
            body.Add("This is a tweet AAP");

            Assert.AreEqual(textSpeakSanitiser.Sanatise(body), "@andrewTest\n This is a tweet AAP <Always a pleasure>");
        }

        [TestMethod]
        public void DoesSanitiseReturnCorrectlyFormattedBodyForSms()
        {
            TextSpeakSanitiser textSpeakSanitiser = new TextSpeakSanitiser();
            List<string> body = new List<string>();
            body.Add("12345678911");
            body.Add("This is an SMS");

            Assert.AreEqual(textSpeakSanitiser.Sanatise(body), "12345678911\n This is an SMS");
        }

        [TestMethod]
        public void DoesSanitiseReturnCorrectlyFormattedBodyForSmsWithTextSpeak()
        {
            TextSpeakSanitiser textSpeakSanitiser = new TextSpeakSanitiser();
            List<string> body = new List<string>();
            body.Add("12345678911");
            body.Add("This is an SMS AAP");

            Assert.AreEqual(textSpeakSanitiser.Sanatise(body), "12345678911\n This is an SMS AAP <Always a pleasure>");
        }
    }
}
