using System.Collections.Generic;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Strategies;

namespace FindWay.Interfaces.Services
{
    public interface IWaysService
    {
        IWayFinderStrategy WayFinderStrategy { get; set; }
        List<IRoute> FindWay(IGraph graph, INode startNode, INode endNode);
        List<IRoute> FindWay(IGraph graph, params INode[] nodes);
    }
}