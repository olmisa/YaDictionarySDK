using System.Collections.Generic;

using Newtonsoft.Json;

using JsonNames = YaDictionarySDK.Common.Constants.JsonPropertiesNames;

namespace YaDictionarySDK.Web
{
    public class YaDefinition
    {
        [JsonProperty(JsonNames.Text)]
        public string Text { get; private set; }

        [JsonProperty(JsonNames.Pos)]
        public string Pos { get; private set; }

        [JsonProperty(JsonNames.Gen)]
        public string Gen { get; private set; }

        [JsonProperty(JsonNames.Ts)]
        public string Ts { get; private set; }

        [JsonProperty(JsonNames.Fl)]
        public string Fl { get; private set; }

        [JsonProperty(JsonNames.Tr)]
        public List<YaTranslation> Translations { get; private set; }
    }
}
