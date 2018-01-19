using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindWay.Infrastructure.Models;
using FindWay.Infrastructure.Services;
using FindWay.Infrastructure.Strategies;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Services;
using FindWay.Interfaces.Strategies;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            INode first = new Node();
            INode second = new Node();
            INode third = new Node();
            first.Routes.Add(new Route
            {
                FromNode = first,
                ToNode = third,
                Duration = 5,
                Cost = 10
            });
            first.Routes.Add(new Route
            {
                FromNode = first,
                ToNode = second,
                Duration = 1,
                Cost = 100
            });
            second.Routes.Add(new Route
            {
                FromNode = second,
                ToNode = third,
                Duration = 3,
                Cost = 30
            });

            IGraph graph = new Graph(new List<INode> { first, second, third });
            var copy = graph;
            var binder = new DefaultSerializationBinder();
            var jsonConverter = new JsonTypesConveter();
            jsonConverter.AddTypeMatching(typeof(INode), typeof(Node));
            jsonConverter.AddTypeMatching(typeof(IRoute), typeof(Route));
            jsonConverter.AddTypeMatching(typeof(IGraph), typeof(Graph));
            
            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Converters = { jsonConverter }
            };

            using (var writer = new StreamWriter("output.json"))
            {
                serializer.Serialize(writer, graph, typeof(IGraph));
            }
            using (var reader = new StreamReader("output.json"))
            {
                graph = serializer.Deserialize<IGraph>(new JsonTextReader(reader));
            }
            using (var writer = new StreamWriter("output1.json"))
            {
                serializer.Serialize(writer, graph, typeof(IGraph));
            }
            IWayFinderStrategy wayFinder = new CheapestWayFinder();
            IWaysService waysService = new WaysService(wayFinder);
            var way = waysService.FindWay(graph, graph.First(), graph.Last());
            Console.WriteLine($"Total way cost: {way.Sum(r => r.Cost)}");
        }
    }
}
