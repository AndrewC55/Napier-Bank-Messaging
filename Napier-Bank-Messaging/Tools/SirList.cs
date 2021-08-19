using System.Collections.Generic;
using System.IO;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Tools
{
    public class SirList
    {
        // function to get incidents
        public List<string> GetNatureOfIncidentsValues()
        {
            // read all lines from incidents list
            string[] values = File.ReadAllLines(FilePathEnum.IncidentFilePath);
            // create a string list to store values of list
            List<string> allValues = new List<string>();

            // foreach through array and add to list
            foreach (string value in values)
            {
                allValues.Add(value);
            }

            // return list
            return allValues;
        }

        // function to write store sir list
        public void WriteToSirList(string header, string sortCode, string natureOfIncident)
        {
            // write sir sort code and nature of incident to file
            File.AppendAllText(FilePathEnum.SirListFilePath, header + "\n" + sortCode + "\n" + natureOfIncident + "\n");
        }
    }
}
