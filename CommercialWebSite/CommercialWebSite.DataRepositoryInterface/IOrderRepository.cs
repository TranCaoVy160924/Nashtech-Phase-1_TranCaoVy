using CommercialWebSite.ShareDTO.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.DataRepositoryInterface
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetByBuyerIdAsync(string buyerId);
        Task<OrderModel> IncreaseProductNumAsync(int orderId);
        Task<OrderModel> SubProductNumAsync(int orderId);
        Task<OrderModel> CreateOrderAsync(OrderModel newOrder);
        Task DeleteOrderAsync(int orderId);
        Task CheckoutAsync(List<int> checkingOutOrderIds);
    }
}
