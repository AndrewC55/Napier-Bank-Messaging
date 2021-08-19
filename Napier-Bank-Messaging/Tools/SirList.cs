using System.Collections.Generic;
using System.IO;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Tools
{
    public class SirList
    {
        public List<string> GetNatureOfIncidentsValues()
        {
            string[] values = File.ReadAllLines(FilePathEnum.IncidentFilePath);
            List<string> allValues = new List<string>();

            foreach (string value in values)
            {
                allValues.Add(value);
            }

            return allValues;
        }

        public void WriteToSirList(string header, string sortCode, string natureOfIncident)
        {
            File.AppendAllText(FilePathEnum.SirListFilePath, header + "\n" + sortCode + "\n" + natureOfIncident + "\n");
        }
    }
}
