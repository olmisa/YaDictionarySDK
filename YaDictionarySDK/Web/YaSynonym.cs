using JsonNames = YaDictionarySDK.Common.Constants.JsonPropertiesNames;
using YaDictionarySDK.Web.Interfaces;
using Newtonsoft.Json;

namespace YaDictionarySDK.Web
{
    public class YaSynonym : ISynonym
    {
        [JsonProperty(JsonNames.Text)]
        public string Text { get; private set; }

        [JsonProperty(JsonNames.Pos)]
        public string Pos { get; private set; }

        [JsonProperty(JsonNames.Fr)]
        public int Fr { get; private set; }

        [JsonProperty(JsonNames.Gen, NullValueHandling = NullValueHandling.Ignore)]
        public string Gen { get; private set; }
    }
}
