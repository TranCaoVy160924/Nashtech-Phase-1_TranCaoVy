using DataAccess.DataModel;
using DataRepositoryInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareModelsDTO.Business;

namespace CommercialWebSiteAPI.Controllers
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
        public async Task<List<ProductModel>> GetAll()
        {
            List<ProductModel> allProducts = await _productRepository.GetAllProductAsync();
            
            return allProducts;
        }
    }
}
