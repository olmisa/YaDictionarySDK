using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using YaDictionarySDK.Web.Interfaces;

namespace YaDictionarySDK
{
    public interface IWordsDictionary
    {
        Task<List<string>> GetLanguagesAsync(CancellationToken? _cancellationToken = null);
        Task<List<string>> GetTranslationAsync(string _textToTranslate, string _selectedLanguage, CancellationToken? _cancellationToken = null);
        Task<IDictionaryResponse> GetTranslationFullResponseAsync(string _textToTranslate, string _selectedLanguage, CancellationToken? _cancellationToken = null);
    }
}
