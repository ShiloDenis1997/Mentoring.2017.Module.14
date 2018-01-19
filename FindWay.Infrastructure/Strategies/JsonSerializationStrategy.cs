using System.IO;
using FindWay.Infrastructure.Strategies.Abstract;
using Newtonsoft.Json;

namespace FindWay.Infrastructure.Strategies
{
    public class JsonSerializationStrategy : ISerializationStrategy
    {
        private readonly JsonSerializer _serializer;

        public JsonSerializationStrategy(JsonSerializer serializer)
        {
            _serializer = serializer;
        }

        public T Deserialize<T>(Stream inputStream)
        {
            using (var jsonReader = new JsonTextReader(new StreamReader(inputStream)))
            {
                return _serializer.Deserialize<T>(jsonReader);
            }
        }

        public void Serialize<T>(Stream outputStream, T value)
        {
            using (var jsonWriter = new JsonTextWriter(new StreamWriter(outputStream)))
            {
                _serializer.Serialize(jsonWriter, value);
            }
        }
    }
}