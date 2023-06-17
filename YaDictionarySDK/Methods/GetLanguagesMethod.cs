using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace YaDictionarySDK.Methods
{
    internal class GetLanguagesMethod : YaDictionaryBaseMethod, IYaDictionaryMethod<List<string>>
    {
        public GetLanguagesMethod(string _apiKey) : base(_apiKey){}

        protected override string MethodUrl => "https://dictionary.yandex.net/api/v1/dicservice.json/getLangs?key={0}";
        public async Task<List<string>> GetResult(CancellationToken? _cancellationToken)
        {
            var responseContentJson = await GetResponseContent(string.Format(MethodUrl, apiKey), _cancellationToken);
            return JsonConvert.DeserializeObject<List<string>>(responseContentJson);
        }
    }
}
