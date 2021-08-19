using System.IO;
using System.Text.Json;
using Napier_Bank_Messaging.Messages;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Tools
{
    public class JsonAPI
    {
        // function to emulate json api
        public void ToJson(Message message)
        {
            // serialize entire message object
            string jsonSerialized = JsonSerializer.Serialize(message);
            // write serialized object to file
            File.AppendAllText(FilePathEnum.JsonFilePath, jsonSerialized + "\n");
        }
    }
}
