﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using YaDictionarySDK.Web;

namespace YaDictionarySDK.Methods
{
    internal class GetTranslationAsyncMethod : YaDictionaryAsyncMethod, IYaDictionaryAsyncMethod<List<string>>
    {
        private string selectedLanguage;
        private string textToTranslate;
        protected override string MethodUrl => "https://dictionary.yandex.net/api/v1/dicservice.json/lookup?key={1}&lang={2}&text={0}";

        public GetTranslationAsyncMethod(string _textToTranslate, string _selectedLanguage, string _apiKey) : base(_apiKey)
        {
            textToTranslate = _textToTranslate;
            selectedLanguage = _selectedLanguage;
        }

        public async Task<List<string>> GetResult(CancellationToken? _cancellationToken = null)
        {
            var responseContentJson = await GetResponseContent(string.Format(MethodUrl, textToTranslate, apiKey, selectedLanguage), _cancellationToken);
            var yaResponse = JsonConvert.DeserializeObject<YaResponse>(responseContentJson);
            List<string> result = new List<string>();
            if (yaResponse != null && yaResponse.Def != null && yaResponse.Def.Count > 0)
            {
                var firstDef = yaResponse.Def[0];
                result = firstDef.Translations.Select(t => t.Text).ToList();
            }

            return result;
        }
    }
}
