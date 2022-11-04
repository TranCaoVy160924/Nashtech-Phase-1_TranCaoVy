using CommercialWebSite.ShareDTO.Business;
using Refit;

namespace CommercialWebSite.Client.RefitClient
{
    public interface IOrderClient
    {
        [Get("/Order/{buyerId}")]
        Task<List<OrderModel>> GetByBuyerIdAsync(string buyerId);
    }
}
