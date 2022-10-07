using Newtonsoft.Json;
using System.Collections.Generic;
using YaDictionarySDK.Common.Converters;
using YaDictionarySDK.Web.Interfaces;
using JsonNames = YaDictionarySDK.Common.Constants.JsonPropertiesNames;

namespace YaDictionarySDK.Web
{
    public class YaTranslation : ITranslation
    {
        [JsonProperty(JsonNames.Text)]
        public string Text { get; private set; }

        [JsonProperty(JsonNames.Pos)]
        public string Pos { get; private set; }

        [JsonProperty(JsonNames.Gen, NullValueHandling = NullValueHandling.Ignore)]
        public string Gen { get; private set; }

        [JsonProperty(JsonNames.Fr)]
        public int Fr { get; private set; }

        [JsonProperty(JsonNames.Mean, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(InterfaceListToTypeListConverter<IText, YaText>))]
        public List<IText> Mean { get; private set; }

        [JsonProperty(JsonNames.Syn, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(InterfaceListToTypeListConverter<ISynonym, YaSynonym>))]
        public List<ISynonym> Syn { get; private set; }

        [JsonProperty(JsonNames.Ex, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(InterfaceListToTypeListConverter<IExample, YaExample>))]
        public List<IExample> Ex { get; private set; }

        [JsonProperty(JsonNames.Asp, NullValueHandling = NullValueHandling.Ignore)]
        public string Asp { get; private set; }
    }
}
