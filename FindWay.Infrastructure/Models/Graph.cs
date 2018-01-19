using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FindWay.Interfaces.Models;

namespace FindWay.Infrastructure.Models
{
    public class Graph : IGraph
    {
        public Graph() :this(new List<INode>())
        {}

        public Graph(List<INode> nodes)
        {
            Nodes = nodes;
        }

        public ICollection<INode> Nodes { get; set; }
    }
}