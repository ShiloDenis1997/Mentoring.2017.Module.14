using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindWay.Infrastructure.Services.Abstract;
using FindWay.Infrastructure.Strategies.Abstract;

namespace FindWay.Infrastructure.Services
{
    public class SerializationService : ISerializationService
    {
        public SerializationService(ISerializationStrategy serializationStrategy)
        {
            SerializationStrategy = serializationStrategy;
        }

        public ISerializationStrategy SerializationStrategy { get; set; }

        public T Deserialize<T>(Stream inputStream)
        {
            return SerializationStrategy.Deserialize<T>(inputStream);
        }

        public void Serialize<T>(Stream outputStream, T value)
        {
            SerializationStrategy.Serialize(outputStream, value);
        }
    }
}
