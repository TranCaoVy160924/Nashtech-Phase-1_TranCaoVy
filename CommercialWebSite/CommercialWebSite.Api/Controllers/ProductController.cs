using CommercialWebSite.DataRepositoryInterface;
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
        public async Task<List<ProductModel>> GetAllAsync()
        {
            List<ProductModel> allProducts = await _productRepository.GetAllProductAsync();
            
            return allProducts;
        }

        [HttpGet]
        [Route("Feature")]
        public async Task<List<ProductModel>> GetFeatureProductAsync()
        {
            List<ProductModel> allProducts = await _productRepository.GetFeatureProductAsync();

            return allProducts;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            ProductModel product = await _productRepository.GetProductByIdAsync(id);

            return product;
        }


    }
}
