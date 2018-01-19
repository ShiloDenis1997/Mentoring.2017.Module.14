using System.IO;
using FindWay.Interfaces.Models;

namespace CUI
{
    public interface IGraphSerializer
    {
        IGraph Load(Stream inputStream);
        void Save(Stream outputStream, IGraph graph);
    }
}