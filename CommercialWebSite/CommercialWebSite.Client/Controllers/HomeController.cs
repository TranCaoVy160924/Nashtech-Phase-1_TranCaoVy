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
        private ViewModel LayoutViewModel { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //var session = Request.HttpContext.Session;
            //string jwtToken = session.GetString("JwtAuthToken");
            //if (jwtToken != null)
            //{
            //    _logger.LogInformation("Auth token: " + jwtToken);
            //    IWeatherForecastClient client = RestService.For<IWeatherForecastClient>(baseUrl, new RefitSettings()
            //    {
            //        AuthorizationHeaderValueGetter = () =>
            //            Task.FromResult(jwtToken)
            //    });

            //    List<WeatherForecastModel> weather = await client.GetWeatherForecastAsync();

            //    _logger.LogInformation("Weather: " + weather);
            //}

            IProductClient productClient = RestService.For<IProductClient>(baseUrl);
            var products = await productClient.GetFeatureProductAsync();

            ViewModel viewModel = new ViewModel();
            viewModel.ProductModels = products;

            return View(viewModel);
        }

        public async Task<IActionResult> Shop()
        {
            IProductClient productClient = RestService.For<IProductClient>(baseUrl);
            var products = await productClient.GetAllProductAsync();

            ViewModel viewModel = new ViewModel();
            viewModel.ProductModels = products;
            return View(viewModel);
        }

        public async Task<IActionResult> ProductDetail(int id)
        {
            IProductClient productClient = RestService.For<IProductClient>(baseUrl);
            var product = await productClient.GetProductByIdAsync(id);

            ViewModel viewModel = new ViewModel();
            viewModel.ProductDetail = product;

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}