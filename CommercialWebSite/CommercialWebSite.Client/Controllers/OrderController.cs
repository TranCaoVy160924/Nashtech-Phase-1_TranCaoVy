using CommercialWebSite.Client.Helper;
using CommercialWebSite.Client.RefitClient;
using CommercialWebSite.ShareDTO;
using CommercialWebSite.ShareDTO.Auth;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System.IdentityModel.Tokens.Jwt;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace CommercialWebSite.Client.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private static readonly string baseUrl = "https://localhost:7281";
        private readonly IOrderClient _orderClient;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
            _orderClient = RestService.For<IOrderClient>(baseUrl);
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var session = Request.HttpContext.Session;
            JwtManager jwtManager = new JwtManager(session);
            string authHeader = jwtManager.GetAuthHeader();
            bool isAuthenticated = jwtManager.IsAuthenticated;

            var userId = jwtManager.GetUserId();

            List<OrderModel> orders = await _orderClient
                .GetByBuyerIdAsync(userId, authHeader);
            session.SetString("Orders", JsonConvert.SerializeObject(orders));

            ViewModel viewModel = new ViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder(ViewModel viewModel) 
        {
            var session = Request.HttpContext.Session;
            JwtManager jwtManager = new JwtManager(session);
            string authHeader = jwtManager.GetAuthHeader();
            OrderModel newOrder = viewModel.NewOrder;
            try
            {
                OrderModel order = await _orderClient
                    .CreateOrderAsync(newOrder, authHeader);
                List<OrderModel> orders = JsonConvert
                    .DeserializeObject<List<OrderModel>>(
                        session.GetString("Orders"));
                if (order.IsNew.Value == true)
                {
                    // Add order to cart if new 
                    orders.Add(order);
                }
                else
                {
                    // Find exsited order and update
                    OrderModel existedOrder = orders
                        .Where(o => o.OrderId == order.OrderId)
                        .FirstOrDefault();
                    existedOrder = order;
                }
                session.SetString("Orders", 
                    JsonConvert.SerializeObject(orders));

                TempData["CreateOrderStatus"] = true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }

            return RedirectToAction("ProductDetail", "Home", new { id = newOrder.ProductId });
        }

        [Authorize]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            try
            {
                var session = Request.HttpContext.Session;
                string authHeader = new JwtManager(session).GetAuthHeader();

                _logger.LogInformation("Deleting order: " + orderId);
                _orderClient.CancelOrderAsync(orderId, authHeader);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }

            return RedirectToAction("Index", "Order");
        }

        [Authorize]
        public async Task<IActionResult> CheckOut()
        {
            try
            {
                var session = Request.HttpContext.Session;
                string authHeader = new JwtManager(session).GetAuthHeader();
                List<OrderModel> orders = JsonConvert
                    .DeserializeObject<List<OrderModel>>(
                        session.GetString("Orders"));

                List<int> checkingOutOrderIds = orders
                    .Where(o => !o.IsCheckedOut)
                    .Select(o => o.OrderId)
                    .ToList();

                await _orderClient
                    .CheckoutAsync(checkingOutOrderIds, authHeader);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }

            return RedirectToAction("Index", "Order");
        }
    }
}
