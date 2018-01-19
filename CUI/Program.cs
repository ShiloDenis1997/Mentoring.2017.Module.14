using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FindWay.Infrastructure.Converters;
using FindWay.Infrastructure.Models;
using FindWay.Infrastructure.Services;
using FindWay.Infrastructure.Services.Abstract;
using FindWay.Infrastructure.Strategies;
using FindWay.Infrastructure.Strategies.Abstract;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Services;
using FindWay.Interfaces.Strategies;
using Newtonsoft.Json;

namespace CUI
{
    class Program
    {
        private static ISerializationService _serializationService;
        private static IWaysService _waysService;

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
            ConfigureApp();

            IGraph graph;
            using (var fileStream = new FileStream("input.json", FileMode.Open))
            {
                graph = _serializationService.Deserialize<IGraph>(fileStream);
            }
            using (var fileStream = new FileStream("output.json", FileMode.OpenOrCreate))
            {
                _serializationService.Serialize(fileStream, graph);
            }

            var way = _waysService.FindWay(graph, graph.Nodes.First(), graph.Nodes.Last());
            Console.WriteLine($"Total way cost: {way.Sum(r => r.Cost)}");
            Console.WriteLine($"Total way duration: {way.Sum(r => r.Duration)}");

            way = _waysService.FindWay(graph, graph.Nodes.Take(1).First(), graph.Nodes.Skip(1).Take(1).First(), graph.Nodes.Last());
            Console.WriteLine($"Total way cost: {way.Sum(r => r.Cost)}");
            Console.WriteLine($"Total way duration: {way.Sum(r => r.Duration)}");
        }

        private static void ConfigureApp()
        {
            ConfigureSerializationService();
            ConfigureWaysService();
        }

        private static void ConfigureWaysService()
        {
            _waysService = new WaysService(new CheapestWayFinder());
        }

        private static void ConfigureSerializationService()
        {
            var jsonConverter = new JsonTypesConveter();
            jsonConverter.AddTypeMatching(typeof(IGraph), typeof(Graph));
            jsonConverter.AddTypeMatching(typeof(INode), typeof(Node));
            jsonConverter.AddTypeMatching(typeof(IRoute), typeof(Route));

            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Converters = { jsonConverter }
            };

            _serializationService = new SerializationService(new JsonSerializationStrategy(serializer));
        }
    }
}
