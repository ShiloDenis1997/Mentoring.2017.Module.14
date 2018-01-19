using System.Collections.Generic;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Services;
using FindWay.Interfaces.Strategies;

namespace FindWay.Infrastructure.Services
{
    public class WaysService : IWaysService
    {
        private readonly IWayFinderStrategy _wayFinder;

        public WaysService(IWayFinderStrategy wayFinder)
        {
            _wayFinder = wayFinder;
        }

        public List<IRoute> FindWay(IGraph graph, INode startNode, INode endNode)
        {
            return _wayFinder.FindWay(graph, startNode, endNode);
        }

        public List<IRoute> FindWay(IGraph graph, params INode[] nodes)
        {
            var result = new List<IRoute>();
            for (int i = 1; i < nodes.Length; i++)
            {
                result.AddRange(_wayFinder.FindWay(graph, nodes[i - 1], nodes[i]));
            }

            return result;
        }
    }
}