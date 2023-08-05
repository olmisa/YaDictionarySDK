using Newtonsoft.Json;
using System.Collections.Generic;

namespace YaDictionarySDK.Methods
{
    internal class GetLanguagesSyncMethod : YaDictionarySyncMethod, IYaDictionarySyncMethod<List<string>>
    {
        public GetLanguagesSyncMethod(string _apiKey) : base(_apiKey){}

        protected override string MethodUrl => "https://dictionary.yandex.net/api/v1/dicservice.json/getLangs?key={0}";
        public List<string> GetResult()
        {
            var responseContentJson = GetResponseContent(string.Format(MethodUrl, apiKey));
            return JsonConvert.DeserializeObject<List<string>>(responseContentJson);
        }
    }
}
