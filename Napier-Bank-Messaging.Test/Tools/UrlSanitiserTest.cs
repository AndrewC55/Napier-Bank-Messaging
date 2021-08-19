using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Napier_Bank_Messaging.Tools;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class UrlSanitiserTest
    {
        [TestMethod]
        public void DoesSanitiseReturnCorrectlyFormattedBodyForEmail()
        {
            UrlSanitiser urlSanitiser = new UrlSanitiser();
            List<string> body = new List<string>();
            string header = "E123456789";
            body.Add("andrew@test.com");
            body.Add("Subject");
            body.Add("This is an email");

            Assert.AreEqual(urlSanitiser.Sanatise(header, body, false), "andrew@test.com\nSubject\n This is an email");
        }

        [TestMethod]
        public void DoesSanitiseReturnCorrectlyFormattedBodyForEmailWithUrl()
        {
            UrlSanitiser urlSanitiser = new UrlSanitiser();
            List<string> body = new List<string>();
            string header = "E123456789";
            body.Add("andrew@test.com");
            body.Add("Subject");
            body.Add("This is an email, here's a link http://Google.com");

            Assert.AreEqual(urlSanitiser.Sanatise(header, body, false), "andrew@test.com\nSubject\n This is an email, here's a link <URL Quarantined>");
        }
    }
}
