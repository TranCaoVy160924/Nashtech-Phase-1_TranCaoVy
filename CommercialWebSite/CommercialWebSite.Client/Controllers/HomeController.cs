using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CommercialWebSite.Client.RefitClient;
using Refit;
using CommercialWebSite.ShareDTO;

namespace CommercialWebSite.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly string baseUrl = "https://localhost:7281";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(List<ProductModel> products)
        {
            var session = Request.HttpContext.Session;
            string jwtToken = session.GetString("JwtAuthToken");
            if (jwtToken != null)
            {
                _logger.LogInformation("Auth token: " + jwtToken);
                IWeatherForecastClient client = RestService.For<IWeatherForecastClient>(baseUrl, new RefitSettings()
                {
                    AuthorizationHeaderValueGetter = () =>
                        Task.FromResult(jwtToken)
                });

                List<WeatherForecastModel> weather = await client.GetWeatherForecastAsync();

                _logger.LogInformation("Weather: " + weather);
            }

            if (products == null)
            {
                IProductClient productClient = RestService.For<IProductClient>(baseUrl);
                products = await productClient.GetAllProductAsync();
                products.ForEach(p =>
                {
                    _logger.LogInformation(p.ProductName + ", Category: " + p.CategoryId);
                });
            }

            ViewModel viewModel = new ViewModel();
            viewModel.ProductModels = products;

            return View(viewModel);
        }

        public async Task<IActionResult> SearchProductByName()
        {
            List<ProductModel> products = new List<ProductModel>();
            return RedirectToAction("Index", products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}