using CommercialWebSite.ShareDTO.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.DataRepositoryInterface
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProductAsync();

        Task<List<ProductModel>> GetFeatureProductAsync();

        Task<List<ProductModel>> GetProductByCategoryAsync(int categoryId);

        Task<ProductModel> GetProductByIdAsync(int id);
    }
}
