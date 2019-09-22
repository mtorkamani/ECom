using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECom.Common.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync(SortOption sortOption);
    }
}