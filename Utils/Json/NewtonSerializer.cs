using Newtonsoft.Json;

namespace Utils.Json
{
    public class NewtonSerializer : ISerializer
    {
        public NewtonSerializer()
        {
        }

        public T Deserialize<T>(string json)
        {
            var jsonObject = JsonConvert.DeserializeObject<T>(json);

            return jsonObject;
        }

        public string Serialize<T>(T input)
        {
            var json = JsonConvert.SerializeObject(input,Formatting.Indented);

            return json;
        }
    }
}
