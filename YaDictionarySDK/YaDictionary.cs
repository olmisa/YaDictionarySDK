using System.Collections.Generic;
using System.Threading.Tasks;

using YaDictionarySDK.Common;
using YaDictionarySDK.Methods;
using YaDictionarySDK.Web;

namespace YaDictionarySDK
{
    public class YaDictionary : IWordsDictionary
    {
        private string apiKey;
        public YaDictionary(string _apiKey)
        {
            apiKey = _apiKey;
        }

        public async Task<List<string>> GetLanguagesAsync()
        {
            CheckApiKey();
            var method = new GetLanguagesMethod(apiKey);
            return await method.GetResult();
        }

        public async Task<List<string>> GetTranslationAsync(string _textToTranslate, string _selectedLanguage)
        {
            CheckApiKey();
            var method = new GetTranslationMethod(_textToTranslate, _selectedLanguage, apiKey);
            return await method.GetResult();
        }

        public async Task<YaResponse> GetTranslationFullResponseAsync(string _textToTranslate, string _selectedLanguage)
        {
            CheckApiKey();
            var method = new GetTranslationFullResponseMethod(_textToTranslate, _selectedLanguage, apiKey);
            return await method.GetResult();
        }

        private void CheckApiKey()
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new YaDictionaryException(Constants.ExceptionMessages.ApiKeyIsEmpty);
            }
        }
    }
}
