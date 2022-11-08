using CommercialWebSite.API.AuthHelper;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetByBuyerIdAsync(string buyerId)
        {
            if ((bool)HttpContext.Items["isValidToken"])
            {
                List<OrderModel> orderModels =
                await _orderRepository.GetByBuyerIdAsync(buyerId);

                return Ok(orderModels);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPatch]
        [Route("Incre/{orderId}")]
        [Authorize]
        public async Task<IActionResult> IncreOrderProductNumAsync(int orderId)
        {
            if ((bool)HttpContext.Items["isValidToken"])
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
            else
            {
                return Unauthorized();
            }
        }

        [HttpPatch]
        [Route("Sub/{orderId}")]
        [Authorize]
        public async Task<IActionResult> SubOrderProductNumAsync(int orderId)
        {
            if ((bool)HttpContext.Items["isValidToken"])
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
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderModel newOrder)
        {
            if ((bool)HttpContext.Items["isValidToken"])
            {
                try
                {
                    OrderModel order = await _orderRepository.CreateOrderAsync(newOrder);

                    return Ok(order);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete]
        [Route("{orderId}")]
        [Authorize]
        public async Task<IActionResult> CancelOrderAsync(int orderId)
        {
            if ((bool)HttpContext.Items["isValidToken"])
            {
                try
                {
                    await _orderRepository.DeleteOrderAsync(orderId);

                    return StatusCode(StatusCodes.Status200OK);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPatch]
        [Route("Checkout")]
        [Authorize]
        public async Task<IActionResult> CheckoutAsync([FromBody] List<int> checkingOutOrderIds)
        {
            if ((bool)HttpContext.Items["isValidToken"])
            {
                try
                {
                    await _orderRepository.CheckoutAsync(checkingOutOrderIds);

                    return StatusCode(StatusCodes.Status200OK);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
