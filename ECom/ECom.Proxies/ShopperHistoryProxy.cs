using ECom.Common;
using ECom.Common.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECom.Proxies
{
    public class ShopperHistoryProxy : IShopperHistoryProxy
    {
        private readonly EComConfiguration configuration;
        private readonly IHttpClientFactory clientFactory;

        public ShopperHistoryProxy(IOptions<EComConfiguration> configuration, IHttpClientFactory clientFactory)
        {
            this.configuration = configuration.Value;
            this.clientFactory = clientFactory;
        }

        public async Task<ShopperHistory> GetShopperHistoryAsync()
        {
            var url = $"{configuration.WooliesXBaseUrl}/api/resource/shopperHistory?token={configuration.Token}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = clientFactory.CreateClient();

            try
            {
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var orders = await response.Content.ReadAsAsync<IEnumerable<Order>>();
                    var history = new ShopperHistory
                    {
                        Orders = orders
                    };
                    return history;
                }
                else
                {
                    throw new ProxyCallException(url, "Invalid response from server");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // TODO: Add logging
                throw new ProxyCallException(url, "Service call failure", ex);
            }
        }
    }
}
