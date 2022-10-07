using System.Collections.Generic;
using JsonNames = YaDictionarySDK.Common.Constants.JsonPropertiesNames;
using YaDictionarySDK.Web.Interfaces;
using Newtonsoft.Json;
using YaDictionarySDK.Common.Converters;

namespace YaDictionarySDK.Web
{
    public class YaExample : IExample
    {
        [JsonProperty(JsonNames.Tr)]
        [JsonConverter(typeof(InterfaceListToTypeListConverter<IText, YaText>))]
        public List<IText> Tr {get; private set;}

        [JsonProperty(JsonNames.Text)]
        public string Text { get; private set; }
    }
}
