using AutoMapper;
using CommercialWebSite.Data.AutoMapperHelper;
using CommercialWebSite.Data.DataModel;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.EntityFrameworkCore;
using CommercialWebSite.DataRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _appDbContext;
        private MapperHelper<Category, CategoryModel> _categoryMapper;
        private IMapperProvider _mapperProvider;

        public CategoryRepository(
            ApplicationDbContext appDbContext,
            IMapperProvider mapperProvider)
        {
            _mapperProvider = mapperProvider;
            _categoryMapper =_mapperProvider.CreateCategoryMapper();
            _appDbContext = new ApplicationDbContext();
        }

        // Implement interface method
        public async Task<List<CategoryModel>> GetAllCategoryAsync()
        {
            var categories = 
                await _appDbContext.Categories
                .Include(c => c.Products)
                .ToListAsync();

            return _categoryMapper.MapCollection(categories).ToList();
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            var category =
                await _appDbContext.Categories
                .Include(c => c.Products)
                .Where(c => c.CategoryId == id)
                .FirstOrDefaultAsync();

            return _categoryMapper.MapSingleObject(category);
        }

        public async Task<List<CategoryModel>> GetFeatureCategoryAsync()
        {
            var categories = await _appDbContext.Categories
                .Include(c => c.Products)
                .OrderByDescending(c => c.Products.Count())
                .Take(4).ToListAsync();

            return _categoryMapper.MapCollection(categories).ToList();
        }

        public async Task<CategoryModel> UpdateCategoryAsync(CategoryModel patchCategory)
        {
            Category category =
                await _appDbContext.Categories
                    .Include(c => c.Products)
                    .Where(c => c.CategoryId == patchCategory.CategoryId)
                    .FirstOrDefaultAsync();

            try
            {
                category.CategoryName = patchCategory.CategoryName;
                category.CategoryPicture = TransformImage(patchCategory.CategoryPicture);

                _appDbContext.SaveChanges();

                return _categoryMapper.MapSingleObject(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                Category category =
                    await _appDbContext.Categories
                    .Where(c => c.CategoryId == id)
                    .FirstOrDefaultAsync();

                _appDbContext.Categories.Remove(category);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryModel> AddCategoryAsync(CategoryModel categoryModel)
        {
            try
            {
                Category category = new Category
                {
                    CategoryName = categoryModel.CategoryName,
                    CategoryPicture = TransformImage(categoryModel.CategoryPicture)
                };

                _appDbContext.Categories.Add(category);
                _appDbContext.SaveChanges();

                return _categoryMapper.MapSingleObject(category);
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Image transform helper
        private static string TransformImage(string image)
        {
            string front = "http://res.cloudinary.com/dddvmxs3h/image/upload/";
            int seperatePosition = front.Length;
            string end = image.Substring(seperatePosition);
            string final = front + "w_150,h_150/" + end;

            return final;
        }
    }
}
