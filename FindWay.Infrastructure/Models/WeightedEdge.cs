using System;
using FindWay.Interfaces.Models;
using QuickGraph;

namespace FindWay.Infrastructure.Models
{
    public class WeightedEdge : IEdge<INode>
    {
        private readonly IRoute _route;
        private readonly Func<IRoute, int> _weightFunc;

        public WeightedEdge(IRoute route, Func<IRoute, int> weightFunc)
        {
            _route = route;
            _weightFunc = weightFunc;
        }

        public IRoute Route => _route;
        public INode Source => _route.FromNode;
        public INode Target => _route.ToNode;
        public int Weight => _weightFunc(_route);
    }
}