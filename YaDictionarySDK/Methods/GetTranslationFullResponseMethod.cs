using System.Threading.Tasks;

using Newtonsoft.Json;

using YaDictionarySDK.Web;

namespace YaDictionarySDK.Methods
{
    internal class GetTranslationFullResponseMethod : YaDictionaryBaseMethod, IYaDictionaryMethod<YaResponse>
    {
        private string selectedLanguage;
        private string textToTranslate;
        protected override string MethodUrl => "https://dictionary.yandex.net/api/v1/dicservice.json/lookup?key={1}&lang={2}&text={0}";

        public GetTranslationFullResponseMethod(string _textToTranslate, string _selectedLanguage, string _apiKey) : base(_apiKey)
        {
            textToTranslate = _textToTranslate;
            selectedLanguage = _selectedLanguage;
        }

        public async Task<YaResponse> GetResult()
        {
            var responseContentJson = await GetResponseContent(string.Format(MethodUrl, textToTranslate, apiKey, selectedLanguage));
            return await Task.Run(() => JsonConvert.DeserializeObject<YaResponse>(responseContentJson));
        }
    }
}
