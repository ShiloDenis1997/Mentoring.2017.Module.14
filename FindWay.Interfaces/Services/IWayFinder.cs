using System.Collections.Generic;
using FindWay.Interfaces.Models;

namespace FindWay.Interfaces.Services
{
    public interface IWayFinder
    {
        List<IRoute> FindWay(IGraph graph, INode startNode, INode endNode);
    }
}