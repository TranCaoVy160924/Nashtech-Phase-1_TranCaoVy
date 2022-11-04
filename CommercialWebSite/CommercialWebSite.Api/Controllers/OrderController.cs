using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommercialWebSite.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository; 
        }

        [HttpGet]
        [Route("{buyerId}")]
        public async Task<IActionResult> GetByBuyerIdAsync(string buyerId)
        {
            List<OrderModel> orderModels =
                await _orderRepository.GetByBuyerIdAsync(buyerId);

            return Ok(orderModels);
        }

        [HttpPatch]
        [Route("Incre/{orderId}")]
        public async Task<IActionResult> IncreOrderProductNumAsync(int orderId)
        {
            try
            {
                OrderModel orderModels =
                    await _orderRepository.IncreaseProductNumAsync(orderId);

                return Ok(orderModels);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch]
        [Route("Sub/{orderId}")]
        public async Task<IActionResult> SubOrderProductNumAsync(int orderId)
        {
            try
            {
                OrderModel orderModels =
                    await _orderRepository.SubProductNumAsync(orderId);

                return Ok(orderModels);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
