using CommercialWebSite.Data.DataModel;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO;
using CommercialWebSite.ShareDTO.Auth;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommercialWebSite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<ProductModel> products = await _productRepository.GetAllProductAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("Feature")]
        public async Task<IActionResult> GetFeatureProductAsync()
        {
            List<ProductModel> products = await _productRepository.GetFeatureProductAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            try
            {
                ProductModel product = await _productRepository.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (NullReferenceException)
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("ByCat/{catId}")]
        public async Task<IActionResult> GetProductByCategoryAsync(int catId)
        {
            List<ProductModel> product = await _productRepository.GetProductByCategoryAsync(catId);
            return Ok(product);
        }

        [HttpGet]
        [Route("ByName/{prodName}")]
        public async Task<IActionResult> GetProductByNameAsync(string prodName)
        {
            List<ProductModel> products = await _productRepository.GetProductByNameAsync(prodName);
            return Ok(products);
        }

        [HttpGet]
        [Route("Filter")]
        public async Task<IActionResult> FilterProductAsync([FromBody] FilterProductModel filter)
        {
            List<ProductModel> products = await _productRepository.FilterProductAsync(filter);
            return Ok(products);
        }
    }
}
