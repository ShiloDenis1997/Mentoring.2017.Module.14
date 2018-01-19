using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FindWay.Interfaces.Models;

namespace FindWay.Infrastructure.Models
{
    public class Graph : IGraph
    {
        private List<INode> _nodes;

        public Graph()
        {
            _nodes = new List<INode>();
        }

        public Graph(List<INode> nodes)
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