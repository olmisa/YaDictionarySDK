using Newtonsoft.Json;
using YaDictionarySDK.Web.Interfaces;
using JsonNames = YaDictionarySDK.Common.Constants.JsonPropertiesNames;

namespace YaDictionarySDK.Web
{
    public class YaText : IText
    {
        [JsonProperty(JsonNames.Text)]
        public string Text { get; private set; }
    }
}
