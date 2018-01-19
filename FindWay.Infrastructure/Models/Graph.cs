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

        public void Add(INode item)
        {
            _nodes.Add(item);
        }

        public void Clear()
        {
            _nodes.Clear();
        }

        public bool Contains(INode item)
        {
            return _nodes.Contains(item);
        }

        public void CopyTo(INode[] array, int arrayIndex)
        {
            _nodes.CopyTo(array, arrayIndex);
        }

        public bool Remove(INode item)
        {
            return _nodes.Remove(item);
        }

        public int Count => _nodes.Count;

        bool ICollection<INode>.IsReadOnly => false;
    }
}