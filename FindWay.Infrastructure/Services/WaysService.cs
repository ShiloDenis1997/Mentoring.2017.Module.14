using System.Collections.Generic;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Services;
using FindWay.Interfaces.Strategies;

namespace FindWay.Infrastructure.Services
{
    public class WaysService : IWaysService
    {
        public WaysService(IWayFinderStrategy wayFinderStrategy)
        {
            WayFinderStrategy = wayFinderStrategy;
        }

        public IWayFinderStrategy WayFinderStrategy { get; set; }

        public List<IRoute> FindWay(IGraph graph, INode startNode, INode endNode)
        {
            return WayFinderStrategy.FindWay(graph, startNode, endNode);
        }

        public List<IRoute> FindWay(IGraph graph, params INode[] nodes)
        {
            var result = new List<IRoute>();
            for (int i = 1; i < nodes.Length; i++)
            {
                result.AddRange(WayFinderStrategy.FindWay(graph, nodes[i - 1], nodes[i]));
            }

            return result;
        }
    }
}