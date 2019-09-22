using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.Common.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductProxy productProxy;
        private readonly IShopperHistoryProxy shopperHistoryProxy;
        private readonly IShopperHistoryAnalyzer shopperHistoryAnalyzer;

        public ProductService(IProductProxy productProxy,
            IShopperHistoryProxy shopperHistoryProxy,
            IShopperHistoryAnalyzer shopperHistoryAnalyzer)
        {
            this.productProxy = productProxy;
            this.shopperHistoryProxy = shopperHistoryProxy;
            this.shopperHistoryAnalyzer = shopperHistoryAnalyzer;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(SortOption sortOption)
        {
            if (sortOption == SortOption.Recommended)
            {
                return await GetSortedProductsFromShopperHistoryProxy();
            }

            var products = await productProxy.GetProductsAsync();
            var sortedProducts = Sort(products, sortOption);
            return sortedProducts;
        }


        private async Task<IEnumerable<Product>> GetSortedProductsFromShopperHistoryProxy()
        {
            var history = await shopperHistoryProxy.GetShopperHistoryAsync();
            var associations = shopperHistoryAnalyzer.CalculateProductAssociations(history);
            var sortedProducts = associations.OrderByDescending(a => a.Popularity).Select(a => a.Product);
            return sortedProducts;
        }

        private IEnumerable<Product> Sort(IEnumerable<Product> products, SortOption sortOption)
        {
            switch (sortOption)
            {
                case SortOption.Low:
                    return products.OrderBy(p => p.Price);
                case SortOption.High:
                    return products.OrderByDescending(p => p.Price);
                case SortOption.Ascending:
                    return products.OrderBy(p => p.Name);
                case SortOption.Descending:
                    return products.OrderByDescending(p => p.Name);
                case SortOption.Recommended:
                default:
                    return products;
            }
        }
    }
}
