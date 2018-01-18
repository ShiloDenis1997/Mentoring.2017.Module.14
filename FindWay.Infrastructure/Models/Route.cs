using FindWay.Interfaces.Models;

namespace FindWay.Infrastructure.Models
{
    public class Route : IRoute
    {
        public INode FromNode { get; set; }
        public INode ToNode { get; set; }
        public int Cost { get; set; }
        public int Duration { get; set; }
    }
}