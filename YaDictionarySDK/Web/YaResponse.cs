using System.Collections.Generic;

using Newtonsoft.Json;
using YaDictionarySDK.Common.Converters;
using YaDictionarySDK.Web.Interfaces;
using JsonNames = YaDictionarySDK.Common.Constants.JsonPropertiesNames;

namespace YaDictionarySDK.Web
{
    public class YaResponse : IDictionaryResponse
    {
        [JsonProperty(JsonNames.Head)]
        public object Head { get; private set; }

        [JsonProperty(JsonNames.Def)]
        [JsonConverter(typeof(InterfaceListToTypeListConverter<IWordEntry, YaDefinition>))]
        public List<IWordEntry> Def { get; private set; }
    }
}
