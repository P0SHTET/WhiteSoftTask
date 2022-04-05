using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
