using CommercialWebSite.ShareDTO.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.APITestUnitTest.DataSetup
{
    public class CategoryDataSetup
    {
        public static async Task<CategoryModel> SingleObjectAsync() =>
            new CategoryModel
            {
                CategoryId = 1,
                CategoryName = "Clothes",
                CategoryPicture = "cat-1.jpg"
            };

        public static async Task<List<CategoryModel>> CollectionAsync()
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            categories.Add(new CategoryModel
            {
                CategoryId = 1,
                CategoryName = "Clothes",
                CategoryPicture = "cat-1.jpg"
            });
            categories.Add(new CategoryModel
            {
                CategoryId = 2,
                CategoryName = "Household",
                CategoryPicture = "cat-2.jpg"
            });
            categories.Add(new CategoryModel
            {
                CategoryId = 3,
                CategoryName = "Electronic",
                CategoryPicture = "cat-3.jpg",
            });
            categories.Add(new CategoryModel
            {
                CategoryId = 4,
                CategoryName = "Beauty",
                CategoryPicture = "cat-4.jpg"
            });
            categories.Add(new CategoryModel
            {
                CategoryId = 5,
                CategoryName = "Book",
                CategoryPicture = "cat-5.jpg"
            });
            categories.Add(new CategoryModel
            {
                CategoryId = 6,
                CategoryName = "Pet",
                CategoryPicture = "cat-6.jpg"
            });

            return categories;
        }

        public static async Task<List<CategoryModel>> EmptyCollectionAsync()
        {
            return new List<CategoryModel>();
        }
    }
}
