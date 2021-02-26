using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExecutionPlanVisualizer.Helpers
{
    static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<TValue>(this HttpClient client, string requestUrl, TValue value)
        {
            var json = JsonSerializer.Serialize(value);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            return client.PostAsync(requestUrl, stringContent);
        }
    }
}