using System.Collections.Generic;
using System.IO;
using FindWay.Infrastructure.Models;
using FindWay.Interfaces.Models;
using Newtonsoft.Json;

namespace CUI
{
    public class JsonGraphSerializer : IGraphSerializer
    {
        private readonly JsonSerializer _serializer;

        public JsonGraphSerializer()
        {
            var jsonConverter = new JsonTypesConveter();
            jsonConverter.AddTypeMatching(typeof(INode), typeof(Node));
            jsonConverter.AddTypeMatching(typeof(IRoute), typeof(Route));

            _serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Converters = { jsonConverter }
            };
        }

        public IGraph Load(Stream inputStream)
        {
            using (var jsonReader = new JsonTextReader(new StreamReader(inputStream)))
            {
                return new Graph(_serializer.Deserialize<List<INode>>(jsonReader));
            }
        }

        public void Save(Stream outputStream, IGraph graph)
        {
            using (var jsonWriter = new JsonTextWriter(new StreamWriter(outputStream)))
            {
                _serializer.Serialize(jsonWriter, graph);
            }
        }
    }
}