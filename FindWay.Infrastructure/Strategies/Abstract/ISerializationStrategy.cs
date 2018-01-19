using System.IO;

namespace FindWay.Infrastructure.Strategies.Abstract
{
    public interface ISerializationStrategy
    {
        T Deserialize<T>(Stream inputStream);
        void Serialize<T>(Stream outputStream, T value);
    }
}