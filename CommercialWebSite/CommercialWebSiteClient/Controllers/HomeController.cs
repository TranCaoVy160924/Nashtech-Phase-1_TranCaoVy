using ClientSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CommercialWebSiteClient.RefitClient;
using Refit;
using Newtonsoft.Json;
using CommercialWebSiteClient.Models;
using ShareModelsDTO.Business;

namespace ClientSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string baseUrl = "https://localhost:7281";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
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

            IProductClient productClient = RestService.For<IProductClient>(baseUrl);
            List<ProductModel> products = await productClient.GetAllProductAsync();
            products.ForEach(p =>
            {
                _logger.LogInformation(p.ProductName + ", Category: " + p.CategoryId);
            });

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}