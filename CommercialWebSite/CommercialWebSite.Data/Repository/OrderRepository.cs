using CommercialWebSite.Data.AutoMapperHelper;
using CommercialWebSite.Data.DataModel;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private ApplicationDbContext _appDbContext;
        private MapperHelper<Order, OrderModel> _orderMapper;
        private IMapperProvider _mapperProvider;

        public OrderRepository(
            ApplicationDbContext appDbContext,
            IMapperProvider mapperProvider)
        {
            _mapperProvider = mapperProvider;
            _orderMapper = _mapperProvider.CreateOrderMapper();
            _appDbContext = appDbContext;
        }

        public async Task<List<OrderModel>> GetByBuyerIdAsync(string buyerId)
        {
            var orderModels =
                await _appDbContext.Orders
                .Include(o => o.Buyer)
                .Include(o => o.Product)
                .ToListAsync();

            return _orderMapper.MapCollection(orderModels).ToList();
        }

        public async Task<OrderModel> IncreaseProductNumAsync(int orderId)
        {
            try
            {
                var order =
                await _appDbContext.Orders
                .Include(o => o.Product)
                .Include(o => o.Buyer)
                .Where(o => o.OrderId == orderId &&
                    !o.IsCheckedOut)
                .FirstOrDefaultAsync();

                order.NumOfGood++;
                _appDbContext.SaveChanges();

                return _orderMapper.MapSingleObject(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderModel> SubProductNumAsync(int orderId)
        {
            try
            {
                var order =
                await _appDbContext.Orders
                .Include(o => o.Product)
                .Include(o => o.Buyer)
                .Where(o => o.OrderId == orderId &&
                    !o.IsCheckedOut)
                .FirstOrDefaultAsync();

                order.NumOfGood--;
                _appDbContext.SaveChanges();

                return _orderMapper.MapSingleObject(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CreateOrderAsync(OrderModel newOrder)
        {
            //try
            //{
            //    UserAccount buyer =
            //        await _appDbContext.UserAccounts
            //        .Where(u => u.Id == newOrder.BuyerId)
            //        .FirstOrDefaultAsync();

            //    Order order = new Order
            //    {
                    
            //    }
            //}
        }
    }
}
