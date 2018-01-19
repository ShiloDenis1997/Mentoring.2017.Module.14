using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FindWay.Infrastructure.Converters
{
    public class JsonTypesConveter : JsonConverter
    {
        private readonly Dictionary<Type, Type> _convertingTypes = new Dictionary<Type, Type>();

        public void AddTypeMatching(Type convertFrom, Type convertTo)
        {
            _convertingTypes.Add(convertFrom, convertTo);
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, _convertingTypes[objectType]);
        }

        public override bool CanConvert(Type objectType)
        {
            return _convertingTypes.ContainsKey(objectType);
        }
    }
}
