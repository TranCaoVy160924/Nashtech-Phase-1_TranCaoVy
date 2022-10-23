using CommercialWebSite.API.Controllers;
using CommercialWebSite.Data.DataModel;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using CommercialWebSite.APITestUnitTest.DataSetup;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace CommercialWebSite.APITestUnitTest.UnitTest
{
    public class ProductControllerTest
    {
        #region GetAllAsync
        [Fact]
        public async Task GetAllAsync_ReturnAllProductFromDatabase()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetAllProductAsync()).Returns(ProductDataSetup.CollectionAsync());
            ProductController controller = new ProductController(mock.Object);

            // Act
            string result = JsonConvert.SerializeObject(await controller.GetAllAsync());

            // Assert
            string expectedResult = JsonConvert
                .SerializeObject(await ProductDataSetup.CollectionAsync());
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnNoProductFromEmptyDatabase()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetAllProductAsync())
                .Returns(ProductDataSetup.EmptyCollectionAsync());
            ProductController controller = new ProductController(mock.Object);

            // Act
            string result = JsonConvert.SerializeObject(await controller.GetAllAsync());

            // Assert
            string expectedResult = JsonConvert
                .SerializeObject(await ProductDataSetup.EmptyCollectionAsync());
            Assert.Equal(expectedResult, result);
        }
        #endregion 

        #region GetFeatureProductAsync
        [Fact]
        public async Task GetFeatureProductAsync_ReturnTopProductFromDatabase()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetAllProductAsync()).Returns(ProductDataSetup.CollectionAsync());
            ProductController controller = new ProductController(mock.Object);

            // Act
            string result = JsonConvert.SerializeObject(await controller.GetAllAsync());

            // Assert
            string expectedResult = JsonConvert
                .SerializeObject(await ProductDataSetup.CollectionAsync());
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GetFeatureProductAsync_ReturnNoProductFromEmptyDatabase()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetAllProductAsync())
                .Returns(ProductDataSetup.EmptyCollectionAsync());
            ProductController controller = new ProductController(mock.Object);

            // Act
            string result = JsonConvert.SerializeObject(await controller.GetAllAsync());

            // Assert
            string expectedResult = JsonConvert
                .SerializeObject(await ProductDataSetup.EmptyCollectionAsync());
            Assert.Equal(expectedResult, result);
        }
        #endregion 

        #region GetProductByIdAsync
        [Fact]
        public async Task GetProductByIdAsync_ReturnSingleProductFromDatabase()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetAllProductAsync()).Returns(ProductDataSetup.CollectionAsync());
            ProductController controller = new ProductController(mock.Object);

            // Act
            string result = JsonConvert.SerializeObject(await controller.GetAllAsync());

            // Assert
            string expectedResult = JsonConvert
                .SerializeObject(await ProductDataSetup.CollectionAsync());
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GetProductByIdAsync_ReturnNoProduct()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetProductByIdAsync(0))
                .Returns<ProductModel>(null);
            ProductController controller = new ProductController(mock.Object);

            // Act
            var actualResult = await controller.GetProductByIdAsync(0);

            // Assert
            actualResult.Should().BeOfType<NoContentResult>();
        }
        #endregion 
    }
}
