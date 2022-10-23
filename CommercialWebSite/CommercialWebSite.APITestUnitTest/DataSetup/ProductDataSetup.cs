using CommercialWebSite.Data.DataModel;
using CommercialWebSite.ShareDTO.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.APITestUnitTest.DataSetup
{
    public class ProductDataSetup
    {
        public void SeedCategory(ApplicationDbContext appDbContext)
        {
            appDbContext.Categories.Add(new Category
            {
                CategoryId = 1,
                CategoryName = "Clothes",
                CategoryPicture = "cat-1.jpg"
            });
            appDbContext.Categories.Add(new Category
            {
                CategoryId = 2,
                CategoryName = "Household",
                CategoryPicture = "cat-2.jpg"
            });
            appDbContext.Categories.Add(new Category
            {
                CategoryId = 3,
                CategoryName = "Electronic",
                CategoryPicture = "cat-3.jpg",
            });
            appDbContext.Categories.Add(new Category
            {
                CategoryId = 4,
                CategoryName = "Beauty",
                CategoryPicture = "cat-4.jpg"
            });
            appDbContext.Categories.Add(new Category
            {
                CategoryId = 5,
                CategoryName = "Book",
                CategoryPicture = "cat-5.jpg"
            });
            appDbContext.Categories.Add(new Category
            {
                CategoryId = 6,
                CategoryName = "Pet",
                CategoryPicture = "cat-6.jpg"
            });
        }

        public async static Task<List<ProductModel>> CollectionAsync()
        {
            List<ProductModel> products = new List<ProductModel>();
            for (int i = 1; i <= 4; i++)
            {
                products.Add(new ProductModel
                {
                    ProductId = i,
                    ProductName = "Product " + i,
                    Description = "Product " + i,
                    ProductPicture = $"product-{i}.jpg",
                    Price = (Double)2000,
                    CreateDate = new DateTime(2022, 10, 23),
                    UpdateDate = new DateTime(2022, 10, 23),
                    CategoryId = 1
                });
            }

            return products;
        }

        public static ProductModel ProductModel()
        {
            ProductModel model = new ProductModel
            {
                ProductId = 1,
                ProductName = "Product " + 1,
                Description = "Product " + 1,
                ProductPicture = $"product-{1}.jpg",
                Price = (Double)2000,
                CreateDate = new DateTime(2022, 10, 23),
                UpdateDate = new DateTime(2022, 10, 23),
                CategoryId = 1
            };

            return model;
        }

        public async static Task<List<ProductModel>> EmptyCollectionAsync()
        {
            List<ProductModel> products = new List<ProductModel>();
            return products;
        }

        //public async static Task NullResultAsync()
        //{
        //    return null;
        //}
    }
}
