using CommercialWebSite.API.Controllers;
using CommercialWebSite.APITestUnitTest.DataSetup;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static CommercialWebSite.APITestUnitTest.TestHelper.ConverterFromIActionResult;
using static CommercialWebSite.APITestUnitTest.DataSetup.AuthDataSetup;

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

        #region GetByIdAsync
        [Fact]
        public async Task GetByIdAsync_ReturnSingleCategory()
        {
            // Arrange
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.GetByIdAsync(1))
                .Returns(CategoryDataSetup.SingleObjectAsync());
            CategoryController controller = new CategoryController(mock.Object);

            // Act
            var result = ConvertOkObject<CategoryModel>(
                await controller.GetByIdAsync(1));

            string expectedResult = JsonConvert
                .SerializeObject(await CategoryDataSetup.SingleObjectAsync());

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnErrorCodeNoContent()
        {
            // Arrange
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.GetByIdAsync(0))
                .Returns<Task<CategoryModel>>(null);
            CategoryController controller = new CategoryController(mock.Object);

            // Act
            var result = await controller.GetByIdAsync(0);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }
        #endregion

        #region DeleteCategoryAsync
        [Fact]
        public async Task DeleteCategoryAsync_Success_ReturnDeletedCategoryId()
        {
            // Arrange
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.DeleteCategoryAsync(1));
            CategoryController controller = new CategoryController(mock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = ConvertOkObject<int>(
                await controller.DeleteCategoryAsync(1));

            string expectedResult = "1";

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DeleteCategoryAsync_Failed_ReturnBadRequestStatusCode()
        {
            // Arrange
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.DeleteCategoryAsync(0))
                .Throws(new Exception("dsfsd"));
            CategoryController controller = new CategoryController(mock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = await controller.DeleteCategoryAsync(0);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        #endregion

        #region UpdateCategoryAsync
        [Fact]
        public async Task UpdateCategoryAsync_Success_ReturnUpdatedCategory()
        {
            // Arrange
            CategoryModel patchCategory = await CategoryDataSetup.SingleObjectAsync();
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.UpdateCategoryAsync(patchCategory))
                .Returns(CategoryDataSetup.SingleObjectAsync());
            CategoryController controller = new CategoryController(mock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = ConvertOkObject<CategoryModel>(
                await controller.UpdateCategoryAsync(patchCategory));

            var expectedResult = JsonConvert.SerializeObject(patchCategory);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UpdateCategoryAsync_Failed_ReturnBadRequestStatusCode()
        {
            // Arrange
            CategoryModel patchCategory = await CategoryDataSetup.SingleObjectAsync();
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.UpdateCategoryAsync(patchCategory))
                .Throws(new Exception("dsfsd"));
            CategoryController controller = new CategoryController(mock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = await controller.UpdateCategoryAsync(patchCategory);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        #endregion

        #region AddCategoryAsync
        [Fact]
        public async Task AddCategoryAsync_Success_ReturnNewCategory()
        {
            // Arrange
            CategoryModel newCategory = await CategoryDataSetup.SingleObjectAsync();
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.AddCategoryAsync(newCategory))
                .Returns(CategoryDataSetup.SingleObjectAsync());
            CategoryController controller = new CategoryController(mock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = ConvertOkObject<CategoryModel>(
                await controller.AddCategoryAsync(newCategory));

            var expectedResult = JsonConvert.SerializeObject(newCategory);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AddCategoryAsync_Failed_ReturnBadRequestStatusCode()
        {
            // Arrange
            CategoryModel newCategory = await CategoryDataSetup.SingleObjectAsync();
            var mock = new Mock<ICategoryRepository>();
            mock.Setup(m => m.AddCategoryAsync(newCategory))
                .Throws(new Exception("dsfsd"));
            CategoryController controller = new CategoryController(mock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = await controller.AddCategoryAsync(newCategory);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        #endregion
    }
}
