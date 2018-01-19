using System.Collections.Generic;
using FindWay.Infrastructure.Models;
using FindWay.Infrastructure.Strategies.Abstract;
using FindWay.Interfaces.Models;
using QuickGraph;
using QuickGraph.Algorithms;

namespace FindWay.Infrastructure.Strategies
{
    public class CheapestWayFinder : BaseQuickGraphWayFinder
    {
        protected override int WeightFunc(IRoute r)
        {
            return r.Cost;
        }

        protected override TryFunc<INode, IEnumerable<WeightedEdge>> FindOptimalWay(IVertexAndEdgeListGraph<INode, WeightedEdge> graph, INode startNode)
        {
            return graph.ShortestPathsBellmanFord(e => e.Weight, startNode);
        }
    }
}