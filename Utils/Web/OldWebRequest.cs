using System.Net;

namespace Utils.Web
{
    public class OldWebRequest : IWebRequest
    {
        public OldWebRequest()
        {
        }

        public string GetDataFromUri(string uri)
        {
            WebRequest requestData = WebRequest.Create(uri);
            WebResponse responseData = requestData.GetResponse();
            Stream dataStream = responseData.GetResponseStream();
            StreamReader readerData = new(dataStream);
            return readerData.ReadToEnd();
        }
    }
}
