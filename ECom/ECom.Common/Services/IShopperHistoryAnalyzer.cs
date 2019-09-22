using System.Collections.Generic;

namespace ECom.Common.Services
{
    public interface IShopperHistoryAnalyzer
    {
        IEnumerable<ProductCustomerAssociation> CalculateProductAssociations(ShopperHistory history);
    }
}