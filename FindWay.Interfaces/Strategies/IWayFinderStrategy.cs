using System.Collections.Generic;
using FindWay.Interfaces.Models;

namespace FindWay.Interfaces.Strategies
{
    public interface IWayFinderStrategy
    {
        List<IRoute> FindWay(IGraph graph, INode startNode, INode endNode);
    }
}