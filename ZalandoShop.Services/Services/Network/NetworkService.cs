using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZalandoShop.Services.Services.Network
{
    public class NetworkService : INetworkService
    {
        private readonly HttpClient client;
        public NetworkService()
        {
            client = new HttpClient();
        }

        public async Task<HttpResult<T>> HttpGetAsync<T>(string url) where T : class
        {
            HttpResponseMessage result = null;
            try
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get
                };

                result = await client.SendAsync(request);
                var responseJson = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (result.IsSuccessStatusCode)
                {
                    var responseObject = JsonConvert.DeserializeObject<T>(responseJson);
                    return new HttpResult<T>(responseObject, result);
                }

                return new HttpResult<T>(null, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
