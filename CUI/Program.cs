using System;
using System.CodeDom;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindWay.Infrastructure.Services;
using FindWay.Interfaces.Models;
using FindWay.Interfaces.Services;

namespace CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factory = new JsonFactory();
            IGraph graph;
            using (var fileStream = new FileStream(args[0], FileMode.Open))
            {
                graph = factory.Create(fileStream);
            }

            IWayFinder wayFinder = new CheapestWayFinder();
            IWaysService waysService = new WaysService(wayFinder);
            var way = waysService.FindWay(graph, graph.First(), graph.Last());
            Console.WriteLine($"Total way cost: {way.Sum(r => r.Cost)}");
        }
    }
}
