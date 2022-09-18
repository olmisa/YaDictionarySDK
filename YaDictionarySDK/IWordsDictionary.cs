using System.Collections.Generic;
using System.Threading.Tasks;
using YaDictionarySDK.Web;

namespace YaDictionarySDK
{
    public interface IWordsDictionary
    {
        Task<List<string>> GetLanguagesAsync();
        Task<List<string>> GetTranslationAsync(string _textToTranslate, string _selectedLanguage);
        Task<YaResponse> GetTranslationFullResponseAsync(string _textToTranslate, string _selectedLanguage);
    }
}
