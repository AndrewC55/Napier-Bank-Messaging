using System.IO;
using System.Text.Json;
using Napier_Bank_Messaging.Messages;
using Napier_Bank_Messaging.Enum;

namespace Napier_Bank_Messaging.Tools
{
    public class JsonAPI
    {
        public void ToJson(Message message)
        {
            string jsonSerialized = JsonSerializer.Serialize(message);
            File.AppendAllText(FilePathEnum.JsonFilePath, jsonSerialized + "\n");
        }
    }
}
