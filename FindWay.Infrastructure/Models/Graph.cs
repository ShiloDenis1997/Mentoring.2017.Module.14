using System.Collections;
using System.Collections.Generic;
using FindWay.Interfaces.Models;

namespace FindWay.Infrastructure.Models
{
    public class Graph : IGraph
    {
        private List<Node> _nodes;

        public Graph(List<Node> nodes)
        {
            _nodes = nodes;
        }

        public IEnumerator<INode> GetEnumerator()
        {
            foreach (var node in _nodes)
            {
                yield return node;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}