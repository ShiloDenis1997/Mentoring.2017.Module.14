using System.Collections.Generic;
using FindWay.Interfaces.Models;

namespace FindWay.Infrastructure.Models
{
    public class Node : INode
    {
        public Node()
        {
            Routes = new List<IRoute>();
        }

        public string City { get; set; }
        public ICollection<IRoute> Routes { get; set; }
    }
}