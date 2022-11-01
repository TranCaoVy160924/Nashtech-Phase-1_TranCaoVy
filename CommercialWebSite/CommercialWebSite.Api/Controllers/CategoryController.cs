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
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            CategoryModel category =
                await _categoryRepository.GetByIdAsync(id);

            return Ok(category);
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

        [HttpPatch]
        [Route("")]
        public async Task<IActionResult> UpdateCategoryAsync(CategoryModel categoryModel)
        {
            try
            {
                await _categoryRepository.UpdateCategoryAsync(categoryModel);
                return Ok(categoryModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            try
            {
                await _categoryRepository.DeleteCategoryAsync(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCategoryAsync(CategoryModel newCategory)
        {
            try
            {
                CategoryModel category = 
                    await _categoryRepository.AddCategoryAsync(newCategory);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
