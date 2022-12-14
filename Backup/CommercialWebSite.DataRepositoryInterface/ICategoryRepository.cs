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

        Task<List<CategoryModel>> GetFeatureCategoryAsync();
    }
}
