using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECom.Common.Services
{
    public interface IProductProxy
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
