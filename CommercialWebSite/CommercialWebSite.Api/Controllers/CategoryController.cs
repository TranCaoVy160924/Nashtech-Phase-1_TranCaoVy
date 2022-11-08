using CommercialWebSite.API.AuthHelper;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Auth;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommercialWebSite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITokenManager _tokenManager;

        public CategoryController(
            ICategoryRepository categoryRepository,
            ITokenManager tokenManager)
        {
            _categoryRepository = categoryRepository;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                CategoryModel category =
                    await _categoryRepository.GetByIdAsync(id);

                return Ok(category);
            }
            catch (NullReferenceException)
            {
                return NoContent();
            }
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
        [Authorize(Roles = UserRoles.Admin)]
        [Route("")]
        public async Task<IActionResult> UpdateCategoryAsync(CategoryModel categoryModel)
        {
            if ((bool)HttpContext.Items["isValidToken"])
            {
                try
                {
                    CategoryModel updatedCategory =
                        await _categoryRepository.UpdateCategoryAsync(categoryModel);
                    return Ok(updatedCategory);
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
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            if ((bool)HttpContext.Items["isValidToken"])
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
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("")]
        public async Task<IActionResult> AddCategoryAsync(CategoryModel newCategory)
        {
            if ((bool)HttpContext.Items["isValidToken"])
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
            else
            {
                return Unauthorized();
            }
        }
    }
}
