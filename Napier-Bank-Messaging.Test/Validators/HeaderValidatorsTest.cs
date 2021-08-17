using Microsoft.VisualStudio.TestTools.UnitTesting;
using Napier_Bank_Messaging.Validators;

namespace Napier_Bank_Messaging.Test
{
    [TestClass]
    public class HeaderValidatorsTest
    {
        [TestMethod]
        public void IsHeaderLengthValid()
        {
            HeaderValidator headerValidator = new HeaderValidator();
            Assert.IsTrue(headerValidator.IsHeaderLengthValid("1234567890"));
        }

        [TestMethod]
        public void IsHeaderLengthNotValid()
        {
            HeaderValidator headerValidator = new HeaderValidator();
            Assert.IsFalse(headerValidator.IsHeaderLengthValid("123"));
        }

        [TestMethod]
        public void IsMessageTypeValid()
        {
            HeaderValidator headerValidator = new HeaderValidator();
            Assert.IsTrue(headerValidator.isMessageTypeValid("E123456789"));
        }

        [TestMethod]
        public void IsMessageTypeNotValid()
        {
            HeaderValidator headerValidator = new HeaderValidator();
            Assert.IsFalse(headerValidator.isMessageTypeValid("1234567890"));
        }

        [TestMethod]
        public void IsMessageFormatValid()
        {
            HeaderValidator headerValidator = new HeaderValidator();
            Assert.IsTrue(headerValidator.isMessageFormatCorrect("E123456789"));
        }

        [TestMethod]
        public void IsMessageFormatNotValid()
        {
            HeaderValidator headerValidator = new HeaderValidator();
            Assert.IsFalse(headerValidator.isMessageFormatCorrect("E1234E6789"));
        }

    }
}

