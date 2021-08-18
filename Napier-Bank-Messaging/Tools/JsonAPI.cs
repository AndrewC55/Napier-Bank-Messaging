using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Text.Json;
using Napier_Bank_Messaging.Messages;

namespace Napier_Bank_Messaging.Tools
{
    class JsonAPI
    {
        private const string FilePath = "C:\\Development\\Napier-Bank-Messaging\\Napier-Bank-Messaging\\Files\\JsonFile.txt";
        public void ToJson(Message message)
        {
            string jsonSerialized = JsonSerializer.Serialize(message);
            File.WriteAllText(FilePath, jsonSerialized);
        }
    }
}
