using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Napier_Bank_Messaging.Tools
{
    class TextSpeakSanitiser
    {
        public static List<TextSpeak> GetTextSpeakerValues()
        {
            string filePath = "";
            string[] values = File.ReadAllLines(filePath);
            List<TextSpeak> allValues = new List<TextSpeak>();
            
            foreach (string value in values)
            {
                string[] row = value.Split(",");
                TextSpeak textSpeak = new TextSpeak();
                textSpeak.Abbreviation = row[0];
                textSpeak.Phrase = row[1];
                allValues.Add(textSpeak);
            }

            return allValues;
        }
    }
}
