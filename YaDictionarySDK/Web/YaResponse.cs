using System.Collections.Generic;

using Newtonsoft.Json;

using JsonNames = YaDictionarySDK.Common.Constants.JsonPropertiesNames;

namespace YaDictionarySDK.Web
{
    public class YaResponse
    {
        [JsonProperty(JsonNames.Head)]
        public object Head { get; private set; }

        [JsonProperty(JsonNames.Def)]
        public List<YaDefinition> Def { get; private set; }
    }
}
