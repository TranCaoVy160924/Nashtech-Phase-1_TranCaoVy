using CommercialWebSite.Data.DataModel;
using CommercialWebSite.ShareDTO.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.AutoMapperHelper
{
    public interface IMapperProvider
    {
        MapperHelper<Product, ProductModel> CreateProductMapper();
        MapperHelper<ProductReview, ProductReviewModel> CreateReviewMapper();
        MapperHelper<Category, CategoryModel> CreateCategoryMapper();
        MapperHelper<UserAccount, UserAccountModel> CreateUserAccountMapper();
    }
}
