using System;
using System.Collections.Generic;
using System.Linq;
using FindWay.Infrastructure.Models;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Strategies;
using QuickGraph;

namespace FindWay.Infrastructure.Strategies.Abstract
{
    public abstract class BaseQuickGraphWayFinder : IWayFinderStrategy
    {
        public List<IRoute> FindWay(IGraph graph, INode startNode, INode endNode)
        {
            AdjacencyGraph<INode, WeightedEdge> quickGraph = new AdjacencyGraph<INode, WeightedEdge>();
            quickGraph.AddVertexRange(graph);
            Func<IRoute, int> weightFunc = WeightFunc;
            quickGraph.AddEdgeRange(graph.SelectMany(n => n.Routes).Select(r => new WeightedEdge(r, weightFunc)));

            var solution = FindOptimalWay(quickGraph, startNode);
            solution(endNode, out var result);
            return result.Select(r => r.Route).ToList();
        }

        protected abstract int WeightFunc(IRoute r);

        protected abstract TryFunc<INode, IEnumerable<WeightedEdge>> FindOptimalWay(IVertexAndEdgeListGraph<INode, WeightedEdge> graph, INode startNode);
    }
}
