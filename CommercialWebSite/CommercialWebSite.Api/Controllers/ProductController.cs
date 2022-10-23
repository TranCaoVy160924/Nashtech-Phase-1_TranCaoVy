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

        // Common response
        private static StatusResponse NoContent = new StatusResponse
        {
            Status = "Error",
            Message = "No Content Found!"
        };

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<List<ProductModel>> GetAllAsync()
        {
            List<ProductModel> products = await _productRepository.GetAllProductAsync();
            
            return products;
        }

        [HttpGet]
        [Route("Feature")]
        public async Task<List<ProductModel>> GetFeatureProductAsync()
        {
            List<ProductModel> products = await _productRepository.GetFeatureProductAsync();

            return products;
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
            catch(NullReferenceException ex)
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("ByCat/{catId}")]
        public async Task<List<ProductModel>> GetProductByCategoryAsync(int catId)
        {
            List<ProductModel> product = await _productRepository.GetProductByCategoryAsync(catId);

            return product;
        }

        [HttpGet]
        [Route("ByName/{prodName}")]
        public async Task<List<ProductModel>> GetProductByNameAsync(string prodName)
        {
            List<ProductModel> product = await _productRepository.GetProductByNameAsync(prodName);

            return product;
        }

        [HttpGet]
        [Route("Filter")]
        public async Task<List<ProductModel>> FilterProduct([FromBody] FilterProductModel filter)
        {
            List<ProductModel> product = await _productRepository.FilterProductAsync(filter);

            return product;
        }
    }
}
