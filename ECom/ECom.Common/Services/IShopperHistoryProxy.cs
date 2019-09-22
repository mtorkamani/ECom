using System.Threading.Tasks;

namespace ECom.Common.Services
{
    public interface IShopperHistoryProxy
    {
        Task<ShopperHistory> GetShopperHistoryAsync();
    }
}
