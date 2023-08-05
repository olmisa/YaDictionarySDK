using System;
using System.Net;
using System.Net.Http;
using YaDictionarySDK.Common;

namespace YaDictionarySDK.Methods
{
    internal class YaDictionarySyncMethod : YaDictionaryBaseMethod
    {
        public YaDictionarySyncMethod(string _apiKey) : base(_apiKey)
        {
        }

        protected string GetResponseContent(string _url)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var content = string.Empty;
                    var requestSender = new WebRequestSender(_url);

                    return requestSender.GetResponseString();
                }
            }
            catch (WebException ex)
            {
                throw new YaDictionaryException($"{Constants.ExceptionMessages.ConnectionProblem}. Exception message: {ex.Message}.");
            }
        }
    }
}
