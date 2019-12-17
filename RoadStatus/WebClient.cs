using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RoadStatus
{
    public class WebClient
    {
        private static readonly HttpClient client = new HttpClient();
        
        public static string GetRoadStatus(string uri, string roadId, string appId, string developerKey)
        {
            SetUpRequestHeaders();
            var response = SendRequest(uri, roadId, appId, developerKey);
            return response;
        }

        private static string SendRequest(string url, string roadId, string appId, string developerKey)
        {
            try
            {
                string result = client.GetStringAsync(url).Result;
                return result;
            }
            catch (System.AggregateException ex)
            {
                return null;
            }
        }

        private static void SetUpRequestHeaders()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Road Corridor Reporter");
        }
    }
}
