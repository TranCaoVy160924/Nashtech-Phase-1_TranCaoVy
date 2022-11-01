using CommercialWebSite.ShareDTO.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.DataRepositoryInterface
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetAllCategoryAsync();
        Task<CategoryModel> GetByIdAsync(int id);
        Task<List<CategoryModel>> GetFeatureCategoryAsync();
        Task<CategoryModel> UpdateCategoryAsync(CategoryModel patchCategory);
        Task DeleteCategoryAsync(int id);
        Task<CategoryModel> AddCategoryAsync(CategoryModel categoryModel);
    }
}
