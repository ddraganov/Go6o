using System;
using System.Net.Http;

namespace Go6oClient.Web.ABConnect
{
    public class ABConnector : IABConnector
    {
        public ABConnector(string url)
        {
            Url = url;
            Client = new HttpClient();
        }

        protected string Url { get; }
        protected HttpClient Client { get; }

        public string GetValue(string testid)
        {
            if (string.IsNullOrWhiteSpace(Url))
            {
                var random = new Random();

                return random.NextDouble() >= 0.5 ? "A" : "B";
            }
            else
            {
                var msg = Client.GetAsync(Url + testid).GetAwaiter().GetResult();

                return msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
    }
}
