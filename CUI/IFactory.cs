using System.IO;
using FindWay.Interfaces.Models;

namespace CUI
{
    public interface IFactory
    {
        IGraph Create(Stream inputStream);
    }
}