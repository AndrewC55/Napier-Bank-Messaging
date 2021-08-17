using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napier_Bank_Messaging.Validators
{
    public class HeaderValidator
    {
        const int HeaderLength = 10;
        const string Sms       = "S";
        const string EMAIL     = "E";
        const string Tweet     = "T";

        public bool IsHeaderLengthValid(string header)
        {
            bool isValid = true;
            if (header.Length != HeaderLength)
            {
                return !isValid;
            }

            return isValid;
        }

        public bool isMessageTypeValid(string header)
        {
            bool isValid = true;
            if ((!header.Contains(Sms)) && (!header.Contains(EMAIL)) && (!header.Contains(Tweet)))
            {
                return !isValid;
            }

            return isValid;
        }
    }
}
