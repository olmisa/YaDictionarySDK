using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;
using YaDictionarySDK.Web;
using YaDictionarySDK.Web.Interfaces;

namespace YaDictionarySDK.Methods
{
    internal class GetTranslationFullResponseAsyncMethod : YaDictionaryAsyncMethod, IYaDictionaryAsyncMethod<IDictionaryResponse>
    {
        private string selectedLanguage;
        private string textToTranslate;
        protected override string MethodUrl => "https://dictionary.yandex.net/api/v1/dicservice.json/lookup?key={1}&lang={2}&text={0}";

        public GetTranslationFullResponseAsyncMethod(string _textToTranslate, string _selectedLanguage, string _apiKey) : base(_apiKey)
        {
            textToTranslate = _textToTranslate;
            selectedLanguage = _selectedLanguage;
        }

        public async Task<IDictionaryResponse> GetResult(CancellationToken? _cancellationToken = null)
        {
            var responseContentJson = await GetResponseContent(string.Format(MethodUrl, textToTranslate, apiKey, selectedLanguage), _cancellationToken);
            return JsonConvert.DeserializeObject<YaResponse>(responseContentJson);
        }
    }
}
