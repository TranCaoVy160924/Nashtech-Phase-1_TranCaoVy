using CommercialWebSite.API.Controllers;
using CommercialWebSite.APITestUnitTest.DataSetup;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static CommercialWebSite.APITestUnitTest.TestHelper.ConverterFromIActionResult;

namespace CommercialWebSite.APITestUnitTest.UnitTest
{
    public class CategoryControllerTest
    {
        #region GetAllAsync
        [Fact]
        public async Task GetAllAsync_ReturnProductListFromDatabase()
        {
            // Arrange
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.GetAllCategoryAsync())
                .Returns(CategoryDataSetup.CollectionAsync());
            CategoryController controller = new CategoryController(mock.Object);

            // Act
            var result = ConvertOkObject<List<CategoryModel>>(
                await controller.GetAllAsync());

            string expectedResult = JsonConvert
                .SerializeObject(await CategoryDataSetup.CollectionAsync());

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnEmptyProductList()
        {
            // Arrange
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.GetAllCategoryAsync())
                .Returns(CategoryDataSetup.EmptyCollectionAsync());
            CategoryController controller = new CategoryController(mock.Object);

            // Act
            var result = ConvertOkObject<List<CategoryModel>>(
                await controller.GetAllAsync());

            string expectedResult = JsonConvert
                .SerializeObject(await CategoryDataSetup.EmptyCollectionAsync());

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion 

        #region GetFeatureCategoryAsync
        [Fact]
        public async Task GetFeatureProductAsync_ReturnProductListFromDatabase()
        {
            // Arrange
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.GetFeatureCategoryAsync())
                .Returns(CategoryDataSetup.CollectionAsync());
            CategoryController controller = new CategoryController(mock.Object);

            // Act
            var result = ConvertOkObject<List<CategoryModel>>(
                await controller.GetFeatureCategoryAsync());

            string expectedResult = JsonConvert
                .SerializeObject(await CategoryDataSetup.CollectionAsync());

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GetFeatureCategoryAsync_ReturnEmptyProductList()
        {
            // Arrange
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.GetFeatureCategoryAsync())
                .Returns(CategoryDataSetup.EmptyCollectionAsync());
            CategoryController controller = new CategoryController(mock.Object);

            // Act
            var result = ConvertOkObject<List<CategoryModel>>(
                await controller.GetFeatureCategoryAsync());

            string expectedResult = JsonConvert
                .SerializeObject(await CategoryDataSetup.EmptyCollectionAsync());

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion 
    }
}
