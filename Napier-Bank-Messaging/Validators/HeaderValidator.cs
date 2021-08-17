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
        const char Sms         = 'S';
        const char EMAIL       = 'E';
        const char Tweet       = 'T';

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
            if ((header[0] != Sms) && (header[0] != EMAIL) && (header[0] != Tweet))
            {
                return !isValid;
            }

            return isValid;
        }

        public bool isMessageFormatCorrect(string header)
        {
            bool isValid = true;
            for (int i = 1; i < HeaderLength + 1; i++)
            {
                if (!(header[i] >= 0 && header[i] <= 9))
                {
                    return !isValid;
                }
            }

            return isValid;
        }
    }
}
