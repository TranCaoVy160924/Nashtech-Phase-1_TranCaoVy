using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Mvc;

namespace CommercialWebSite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<CategoryModel> categories = 
                await _categoryRepository.GetAllCategoryAsync();

            return Ok(categories);
        }

        [HttpGet]
        [Route("Feature")]
        public async Task<IActionResult> GetFeatureCategoryAsync()
        {
            List<CategoryModel> categories = 
                await _categoryRepository.GetFeatureCategoryAsync();

            return Ok(categories);
        }
    }
}
