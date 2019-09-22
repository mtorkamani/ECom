using System.Collections.Generic;

namespace ECom.Common.Services
{
    public class ShopperHistoryAnalyzer : IShopperHistoryAnalyzer
    {
        public IEnumerable<ProductCustomerAssociation> CalculateProductAssociations(ShopperHistory history)
        {
            var associations = new Dictionary<string, ProductCustomerAssociation>();
            foreach (var order in history.Orders)
            {
                foreach (var product in order.Products)
                {
                    if (associations.ContainsKey(product.Name))
                    {
                        associations[product.Name].AddAssociation(product, order);
                    }
                    else
                    {
                        associations.Add(product.Name, new ProductCustomerAssociation(product, order));
                    }
                }
            }
            return associations.Values;
        }
    }
}
