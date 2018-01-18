namespace FindWay.Interfaces.Models
{
    public interface IRoute
    {
        INode FromNode { get; set; }
        INode ToNode { get; set; }
        int Cost { get; set; }
        int Duration { get; set; }
    }
}