using System.Net.Http;

namespace YaDictionarySDK.Methods
{
    internal class YaDictionaryBaseMethod
    {
        virtual protected string MethodUrl { get; }
        protected HttpClient httpClient;
        protected string apiKey;

        public YaDictionaryBaseMethod(string _apiKey)
        {
            apiKey = _apiKey;
        }
    }
}
