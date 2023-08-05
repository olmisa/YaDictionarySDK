using System.IO;
using System.Net;

namespace YaDictionarySDK.Common
{
    internal class WebRequestSender
    {
        HttpWebRequest request = null;

        public WebRequestSender(string uriString)
        {
            request = (HttpWebRequest)WebRequest.Create(uriString);
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
        }

        public void AddHeader(string key, string value)
        {
            request.Headers.Add(key, value);
        }

        public string GetResponseString()
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = string.Empty;
            using (Stream resStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(resStream))
                {
                    responseString = reader.ReadToEnd();
                }
            }

            if (HttpStatusCode.OK > response.StatusCode || response.StatusCode >= HttpStatusCode.Ambiguous)
            {
                throw new YaDictionaryException($"{Constants.ExceptionMessages.BadStatusCode}. Response content: {responseString}.");
            }

            return responseString;
        }
    }
}
