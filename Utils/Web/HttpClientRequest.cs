namespace Utils.Web
{
    public class HttpClientRequest : IWebRequest
    {
        private HttpClient _client;

        public HttpClientRequest()
        {
            _client = new HttpClient();
        }

        public string GetDataFromUri(string uri)
        {          
            Task<string> result = _client.GetStringAsync(uri);
            return result.Result;
        }
    }
}
