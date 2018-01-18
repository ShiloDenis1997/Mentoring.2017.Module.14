using System.Collections.Generic;

namespace FindWay.Interfaces.Models
{
    public interface INode
    {
        ICollection<IRoute> Routes { get; set; }
    }
}