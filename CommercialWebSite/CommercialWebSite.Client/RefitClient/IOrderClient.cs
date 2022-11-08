using CommercialWebSite.ShareDTO.Business;
using Refit;

namespace CommercialWebSite.Client.RefitClient
{
    public interface IOrderClient
    {
        [Get("/Order/{buyerId}")]
        Task<List<OrderModel>> GetByBuyerIdAsync(string buyerId, 
            [Header("Authorization")] string jwtToken);

        [Post("/Order/")]
        Task<OrderModel> CreateOrderAsync(OrderModel newOrder, 
            [Header("Authorization")] string jwtToken);

        [Delete("/Order/{orderId}")]
        Task CancelOrderAsync(int orderId, 
            [Header("Authorization")] string jwtToken);

        [Patch("/Order/Checkout")]
        Task CheckoutAsync([Body] List<int> checkingOutOrderIds,
            [Header("Authorization")] string jwtToken);
    }
}
