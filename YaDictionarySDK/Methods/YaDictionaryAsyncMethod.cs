using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YaDictionarySDK.Common;

namespace YaDictionarySDK.Methods
{
    internal class YaDictionaryAsyncMethod : YaDictionaryBaseMethod
    {
        public YaDictionaryAsyncMethod(string _apiKey) : base(_apiKey)
        {
        }

        protected async Task<string> GetResponseContent(string _url, CancellationToken? _cancellationToken = null)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, _url);
                    var response = _cancellationToken.HasValue ? await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, _cancellationToken.Value)
                                                               : await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                    var content = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new YaDictionaryException($"{Constants.ExceptionMessages.BadStatusCode}. Response content: {content}.");
                    }

                    return content;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new YaDictionaryException($"{Constants.ExceptionMessages.ConnectionProblem}. Exception message: {ex.Message}.");
            }
        }
    }
}
