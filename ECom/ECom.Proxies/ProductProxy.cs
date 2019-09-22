using ECom.Common;
using ECom.Common.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECom.Proxies
{
    public class ProductProxy : IProductProxy
    {
        private readonly EComConfiguration configuration;
        private readonly IHttpClientFactory clientFactory;

        public ProductProxy(IOptions<EComConfiguration> configuration, IHttpClientFactory clientFactory)
        {
            this.configuration = configuration.Value;
            this.clientFactory = clientFactory;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var url = $"{configuration.WooliesXBaseUrl}/api/resource/products?token={configuration.Token}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = clientFactory.CreateClient();

            try
            {
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var products = await response.Content.ReadAsAsync<IEnumerable<Product>>();
                    return products;
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
