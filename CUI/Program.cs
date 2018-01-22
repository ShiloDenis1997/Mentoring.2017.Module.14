using System;
using System.IO;
using System.Linq;
using FindWay.Infrastructure.Converters;
using FindWay.Infrastructure.Models;
using FindWay.Infrastructure.Services;
using FindWay.Infrastructure.Services.Abstract;
using FindWay.Infrastructure.Strategies;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Services;
using Newtonsoft.Json;

namespace CUI
{
    class Program
    {
        private static ISerializationService _serializationService;
        private static IWaysService _waysService;

        static void Main(string[] args)
        {
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
