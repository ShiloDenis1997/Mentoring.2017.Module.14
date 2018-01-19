using System;
using System.IO;
using System.Linq;
using FindWay.Infrastructure.Services;
using FindWay.Infrastructure.Strategies;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Services;
using FindWay.Interfaces.Strategies;

namespace CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //IFactory factory = new JsonFactory();
            //IGraph graph;
            //using (var fileStream = new FileStream(args[0], FileMode.Open))
            //{
            //    graph = factory.Create(fileStream);
            //}
            //INode first = new Node();
            //INode second = new Node();
            //INode third = new Node();
            //first.Routes.Add(new Route
            //{
            //    FromNode = first,
            //    ToNode = third,
            //    Duration = 5,
            //    Cost = 10
            //});
            //first.Routes.Add(new Route
            //{
            //    FromNode = first,
            //    ToNode = second,
            //    Duration = 1,
            //    Cost = 100
            //});
            //second.Routes.Add(new Route
            //{
            //    FromNode = second,
            //    ToNode = third,
            //    Duration = 3,
            //    Cost = 30
            //});

            //IGraph graph = new Graph(new List<INode> { first, second, third });


            IGraph graph;
            IGraphSerializer loader = new JsonGraphSerializer();
            using (var fileStream = new FileStream("input.json", FileMode.Open))
            {
                graph = loader.Load(fileStream);
            }
            using (var fileStream = new FileStream("output.json", FileMode.OpenOrCreate))
            {
                loader.Save(fileStream, graph);
            }
            IWayFinderStrategy wayFinder = new CheapestWayFinder();
            IWaysService waysService = new WaysService(wayFinder);
            var way = waysService.FindWay(graph, graph.First(), graph.Last());
            Console.WriteLine($"Total way cost: {way.Sum(r => r.Cost)}");
            Console.WriteLine($"Total way duration: {way.Sum(r => r.Duration)}");

            way = waysService.FindWay(graph, graph.Take(1).First(), graph.Skip(1).Take(1).First(), graph.Last());
            Console.WriteLine($"Total way cost: {way.Sum(r => r.Cost)}");
            Console.WriteLine($"Total way duration: {way.Sum(r => r.Duration)}");
        }
    }
}
