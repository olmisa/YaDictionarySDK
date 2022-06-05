using Newtonsoft.Json;

using JsonNames = YaDictionarySDK.Common.Constants.JsonPropertiesNames;

namespace YaDictionarySDK.Web
{
    public class YaTranslation
    {
        [JsonProperty(JsonNames.Text)]
        public string Text { get; private set; }

        [JsonProperty(JsonNames.Pos)]
        public string Pos { get; private set; }

        [JsonProperty(JsonNames.Gen)]
        public string Gen { get; private set; }
    }
}
