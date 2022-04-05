using System.Text.Json;

namespace Utils.Json
{
    public class SystemSerializer : ISerializer
    {
        public SystemSerializer()
        {
        }

        public T Deserialize<T>(string input)
        {
            return JsonSerializer.Deserialize<T>(input);
        }

        public string Serialize<T>(T input)
        {
            return JsonSerializer.Serialize(input, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
    }
}
