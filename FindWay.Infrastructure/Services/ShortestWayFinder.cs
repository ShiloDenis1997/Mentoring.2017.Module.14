using System;
using System.Collections.Generic;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Services;
using QuickGraph;
using QuickGraph.Algorithms;

namespace FindWay.Infrastructure.Services
{
    public class WeightedEdge : IEdge<INode>
    {
        private readonly IRoute _route;

        public WeightedEdge(IRoute route)
        {
            _route = route;
        }

        public INode Source => _route.FromNode;
        public INode Target => _route.ToNode;
        public int Weight => _route.Duration;
    }

    public class ShortestWayFinder : IWayFinder
    {
        public List<IRoute> FindWay(IGraph graph, INode startNode, INode endNode)
        {
            AdjacencyGraph<INode, WeightedEdge> quickGraph = new AdjacencyGraph<INode, WeightedEdge>();
            quickGraph.AddVertexRange(graph);

            quickGraph.ShortestPathsDijkstra(e => e.Weight, startNode);
            throw new NotImplementedException();
        }
    }
}