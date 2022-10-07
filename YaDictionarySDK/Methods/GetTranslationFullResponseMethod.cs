﻿using System.Threading.Tasks;

using Newtonsoft.Json;
using YaDictionarySDK.Web;
using YaDictionarySDK.Web.Interfaces;

namespace YaDictionarySDK.Methods
{
    internal class GetTranslationFullResponseMethod : YaDictionaryBaseMethod, IYaDictionaryMethod<IDictionaryResponse>
    {
        private string selectedLanguage;
        private string textToTranslate;
        protected override string MethodUrl => "https://dictionary.yandex.net/api/v1/dicservice.json/lookup?key={1}&lang={2}&text={0}";

        public GetTranslationFullResponseMethod(string _textToTranslate, string _selectedLanguage, string _apiKey) : base(_apiKey)
        {
            textToTranslate = _textToTranslate;
            selectedLanguage = _selectedLanguage;
        }

        public async Task<IDictionaryResponse> GetResult()
        {
            var responseContentJson = await GetResponseContent(string.Format(MethodUrl, textToTranslate, apiKey, selectedLanguage));
            return JsonConvert.DeserializeObject<YaResponse>(responseContentJson);
        }
    }
}
