using CommercialWebSite.Data.DataModel;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.APITestUnitTest.DataSetup
{
    public class ProductDataSetup
    {
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
                    CategoryId = 1
                });
            }

            return products;
        }

        public async static Task<ProductModel> ProductModel()
        {
            ProductModel model = new ProductModel
            {
                ProductId = 1,
                ProductName = "Product " + 1,
                Description = "Product " + 1,
                ProductPicture = $"product-{1}.jpg",
                Price = (Double)2000,
                CategoryId = 1
            };

            return model;
        }

        public async static Task<List<ProductModel>> EmptyCollectionAsync()
        {
            List<ProductModel> products = new List<ProductModel>();
            return products;
        }
    }
}
