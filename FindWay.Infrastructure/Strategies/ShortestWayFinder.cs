using System.Collections.Generic;
using FindWay.Infrastructure.Models;
using FindWay.Infrastructure.Strategies.Abstract;
using FindWay.Interfaces.Models;
using QuickGraph;
using QuickGraph.Algorithms;

namespace FindWay.Infrastructure.Strategies
{
    public class ShortestWayFinder : BaseQuickGraphWayFinder
    {
        protected override int WeightFunc(IRoute r)
        {
            return r.Duration;
        }

        protected override TryFunc<INode, IEnumerable<WeightedEdge>> FindOptimalWay(IVertexAndEdgeListGraph<INode, WeightedEdge> graph, INode startNode)
        {
            return graph.ShortestPathsDijkstra(e => e.Weight, startNode);
        }
    }
}