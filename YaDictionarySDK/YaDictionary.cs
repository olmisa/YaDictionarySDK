using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using YaDictionarySDK.Common;
using YaDictionarySDK.Methods;
using YaDictionarySDK.Web.Interfaces;

namespace YaDictionarySDK
{
    public class YaDictionary : IWordsDictionary
    {
        private string apiKey;
        public YaDictionary(string _apiKey)
        {
            apiKey = _apiKey;
        }

        public async Task<List<string>> GetLanguagesAsync(CancellationToken? _cancellationToken = null)
        {
            CheckApiKey();
            var method = new GetLanguagesAsyncMethod(apiKey);
            return await method.GetResult(_cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<string>> GetTranslationAsync(string _textToTranslate, string _selectedLanguage, CancellationToken? _cancellationToken = null)
        {
            CheckApiKey();
            var method = new GetTranslationAsyncMethod(_textToTranslate, _selectedLanguage, apiKey);
            return await method.GetResult(_cancellationToken).ConfigureAwait(false);
        }

        public async Task<IDictionaryResponse> GetTranslationFullResponseAsync(string _textToTranslate, string _selectedLanguage, CancellationToken? _cancellationToken = null)
        {
            CheckApiKey();
            var method = new GetTranslationFullResponseAsyncMethod(_textToTranslate, _selectedLanguage, apiKey);
            return await method.GetResult(_cancellationToken).ConfigureAwait(false);
        }

        public List<string> GetLanguages()
        {
            CheckApiKey();
            var method = new GetLanguagesSyncMethod(apiKey);
            return method.GetResult();
        }

        public List<string> GetTranslation(string _textToTranslate, string _selectedLanguage)
        {
            CheckApiKey();
            var method = new GetTranslationSyncMethod(_textToTranslate, _selectedLanguage, apiKey);
            return method.GetResult();
        }

        public IDictionaryResponse GetTranslationFullResponse(string _textToTranslate, string _selectedLanguage)
        {
            CheckApiKey();
            var method = new GetTranslationFullResponseSyncMethod(_textToTranslate, _selectedLanguage, apiKey);
            return method.GetResult();
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
