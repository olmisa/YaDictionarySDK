using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace YaDictionarySDK.Common.Converters
{
    internal class InterfaceListToTypeListConverter<T, U> : JsonConverter where U : T
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var res = serializer.Deserialize<List<U>>(reader);
            return res.ConvertAll(x => (T)x);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
