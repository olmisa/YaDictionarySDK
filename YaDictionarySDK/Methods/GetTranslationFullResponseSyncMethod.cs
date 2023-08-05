using Newtonsoft.Json;
using YaDictionarySDK.Web;
using YaDictionarySDK.Web.Interfaces;

namespace YaDictionarySDK.Methods
{
    internal class GetTranslationFullResponseSyncMethod : YaDictionarySyncMethod, IYaDictionarySyncMethod<IDictionaryResponse>
    {
        private string selectedLanguage;
        private string textToTranslate;
        protected override string MethodUrl => "https://dictionary.yandex.net/api/v1/dicservice.json/lookup?key={1}&lang={2}&text={0}";

        public GetTranslationFullResponseSyncMethod(string _textToTranslate, string _selectedLanguage, string _apiKey) : base(_apiKey)
        {
            textToTranslate = _textToTranslate;
            selectedLanguage = _selectedLanguage;
        }

        public IDictionaryResponse GetResult()
        {
            var responseContentJson = GetResponseContent(string.Format(MethodUrl, textToTranslate, apiKey, selectedLanguage));
            return JsonConvert.DeserializeObject<YaResponse>(responseContentJson);
        }
    }
}
