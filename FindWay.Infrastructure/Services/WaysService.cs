using System.Collections.Generic;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Services;

namespace FindWay.Infrastructure.Services
{
    public class WaysService : IWaysService
    {
        private readonly IWayFinder _wayFinder;

        public WaysService(IWayFinder wayFinder)
        {
            _wayFinder = wayFinder;
        }

        public List<IRoute> FindWay(IGraph graph, INode startNode, INode endNode)
        {
            return _wayFinder.FindWay(graph, startNode, endNode);
        }
    }
}