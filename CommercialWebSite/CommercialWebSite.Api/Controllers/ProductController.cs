using CommercialWebSite.API.AuthHelper;
using CommercialWebSite.Data.DataModel;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO;
using CommercialWebSite.ShareDTO.Auth;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Authorization;
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
        [Route("PageCount")]
        public async Task<IActionResult> GetPageCountAsync()
        {          
            int page = await _productRepository.GetPageCountAsync();
            return Ok(page);
        }

        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            if ((bool)HttpContext.Items["isValidToken"])
            {
                List<ProductModel> products = await _productRepository.GetAllAsync();
                return Ok(products);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("Page/{page}")]
        public async Task<IActionResult> GetByPageAsync(int page)
        {
            List<ProductModel> products = await _productRepository.GetProductByPageAsync(page);
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

        [HttpPatch]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProductAsync(ProductModel patchProduct)
        {
            if ((bool)HttpContext.Items["isValidToken"])
            {
                try
                {
                    var product = await _productRepository.UpdateProductAsync(patchProduct);
                    return Ok(product);
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

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("")]
        public async Task<IActionResult> AddProductAsync(ProductModel newProduct)
        {
            if ((bool)HttpContext.Items["isValidToken"])
            {
                try
                {
                    if (newProduct.ProductPicture.Equals(""))
                    {
                        throw new Exception("Product Image Is Required");
                    }
                    var product = await _productRepository.AddProductAsync(newProduct);
                    return Ok(newProduct);
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
        [Authorize(Roles = UserRoles.Admin)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                await _productRepository.DeleteProductAsync(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("CheckBuyer")]
        [Authorize]
        public async Task<IActionResult> CheckBuyerAsync(string buyerId, int productId)
        {
            if ((bool)HttpContext.Items["isValidToken"])
            {
                try
                {
                    bool isBuyer = await _productRepository
                        .CheckBuyerAsync(buyerId, productId);

                    return Ok(isBuyer);
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
