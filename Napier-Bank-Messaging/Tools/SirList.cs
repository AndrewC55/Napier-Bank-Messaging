using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Napier_Bank_Messaging.Tools
{
    public class SirList
    {
        private const string IncidentFilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\NatureOfIncidentList.txt";
        private const string SirFilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\SirList.txt";

        public List<string> GetNatureOfIncidentsValues()
        {
            string[] values = File.ReadAllLines(IncidentFilePath);
            List<string> allValues = new List<string>();

            foreach (string value in values)
            {
                allValues.Add(value);
            }

            return allValues;
        }

        public void WriteToSirList(string header, string sortCode, string natureOfIncident)
        {
            File.AppendAllText(SirFilePath, header + "\n" + sortCode + "\n" + natureOfIncident + "\n");
        }
    }
}
