using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindWay.Infrastructure.Strategies.Abstract;

namespace FindWay.Infrastructure.Services.Abstract
{
    public interface ISerializationService
    {
        ISerializationStrategy SerializationStrategy { get; set; }
        T Deserialize<T>(Stream inputStream);
        void Serialize<T>(Stream outputStream, T value);
    }
}
