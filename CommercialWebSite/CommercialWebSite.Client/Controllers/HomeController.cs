using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CommercialWebSite.Client.RefitClient;
using Refit;
using CommercialWebSite.ShareDTO;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;

namespace CommercialWebSite.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly string baseUrl = "https://localhost:7281";
        private readonly IProductClient _productClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _productClient = RestService.For<IProductClient>(baseUrl);
        }

        public async Task<IActionResult> Index()
        {
            var session = Request.HttpContext.Session;
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

            var products = await _productClient.GetFeatureProductAsync();

            ViewModel viewModel = new ViewModel();
            viewModel.ProductModels = products;

            return View(viewModel);
        }

        public async Task<IActionResult> Shop(ViewModel requestViewModel)
        {
            List<ProductModel> products = requestViewModel.ProductModels;
            if (products == null)
            {
                _logger.LogInformation("Display all product");
                products = await _productClient.GetAllProductAsync();
            }

            ViewModel respsonseViewModel = new ViewModel();
            respsonseViewModel.ProductModels = products;
            return View("Shop", respsonseViewModel);
        }

        public async Task<IActionResult> ProductDetail(int id)
        {
            var product = await _productClient.GetProductByIdAsync(id);

            ViewModel viewModel = new ViewModel();
            viewModel.ProductDetail = product;

            return View(viewModel);
        }

        public async Task<IActionResult> SearchProductByCategory(string catId)
        {
            int categoryId = int.Parse(catId);
            List<ProductModel> products;
            if (categoryId == 0)
            {
                products = await _productClient.GetAllProductAsync();
            } 
            else
            {
                products = await _productClient.GetProductByCategoryAsync(categoryId);
            }

            ViewModel viewModel = new ViewModel
            {
                ProductModels = products
            };

            return await Shop(viewModel);
        }

        public async Task<IActionResult> SearchProductByName(IFormCollection formFields)
        {
            string prodName = formFields["prodName"];
            List<ProductModel> products;
            if (prodName.Trim().Equals(""))
            {
                products = await _productClient.GetAllProductAsync();
            }
            else
            {
                products = await _productClient.GetProductByNameAsync(prodName);
            }

            ViewModel viewModel = new ViewModel
            {
                ProductModels = products
            };

            return await Shop(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}