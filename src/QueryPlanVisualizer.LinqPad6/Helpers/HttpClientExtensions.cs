using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace QueryPlanVisualizer.LinqPad6
{
    static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<TValue>(this HttpClient client, string requestUri, TValue value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            JsonContent content = JsonContent.Create(value, null, options);
            return client.PostAsync(requestUri, content, cancellationToken);
        }
    }
}