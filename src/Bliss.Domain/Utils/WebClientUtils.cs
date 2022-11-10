using System.Net;
using Newtonsoft.Json;

namespace Bliss.Domain.Utils
{
    public static class WebClientUtils
    {
        private static WebClient GetWebClientAutenticado(string accessToken)
        {
            var authorization = $"Bearer {accessToken}";

            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.Headers.Add(HttpRequestHeader.Authorization, authorization);

            return client;
        }

        public static T? DeserializeObject<T>(string endPoint, string accessToken)
        {
            using var client = GetWebClientAutenticado(accessToken);
            var json = client.DownloadString(endPoint);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<T?> DeserializeObjectAsync<T>(string endPoint, string accessToken)
        {
            using var client = GetWebClientAutenticado(accessToken);
            var uri = new Uri(endPoint);
            var json = await client.DownloadStringTaskAsync(uri);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
