using System;
using System.Collections.Generic;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Services;

namespace FindWay.Infrastructure.Services
{
    public class CheapestWayFinder : IWayFinder
    {
        public List<IRoute> FindWay(IGraph graph, INode startNode, INode endNode)
        {
            throw new NotImplementedException();
        }
    }
}