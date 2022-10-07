using System.Collections.Generic;

using Newtonsoft.Json;
using YaDictionarySDK.Common.Converters;
using YaDictionarySDK.Web.Interfaces;
using JsonNames = YaDictionarySDK.Common.Constants.JsonPropertiesNames;

namespace YaDictionarySDK.Web
{
    public class YaDefinition : IWordEntry
    {
        [JsonProperty(JsonNames.Text)]
        public string Text { get; private set; }

        [JsonProperty(JsonNames.Pos)]
        public string Pos { get; private set; }

        [JsonProperty(JsonNames.Gen, NullValueHandling = NullValueHandling.Ignore)]
        public string Gen { get; private set; }

        [JsonProperty(JsonNames.Ts, NullValueHandling = NullValueHandling.Ignore)]
        public string Ts { get; private set; }

        [JsonProperty(JsonNames.Fl)]
        public string Fl { get; private set; }

        [JsonProperty(JsonNames.Tr)]
        [JsonConverter(typeof(InterfaceListToTypeListConverter<ITranslation, YaTranslation>))]
        public List<ITranslation> Translations { get; private set; }
    }
}
