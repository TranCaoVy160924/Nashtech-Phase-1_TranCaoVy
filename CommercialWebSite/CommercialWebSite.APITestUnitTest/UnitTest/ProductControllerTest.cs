//using CommercialWebSite.API.Controllers;
//using CommercialWebSite.Data.DataModel;
//using CommercialWebSite.DataRepositoryInterface;
//using CommercialWebSite.ShareDTO.Business;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using Newtonsoft.Json;
//using CommercialWebSite.APITestUnitTest.DataSetup;
//using Microsoft.AspNetCore.Mvc;
//using FluentAssertions;
//using CommercialWebSite.ShareDTO;
//using static CommercialWebSite.APITestUnitTest.TestHelper.ConverterFromIActionResult;

//namespace CommercialWebSite.APITestUnitTest.UnitTest
//{
//    public class ProductControllerTest
//    {
//        #region GetAllAsync
//        [Fact]
//        public async Task GetAllAsync_ReturnAllProductFromDatabase()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetAllAsync()).Returns(ProductDataSetup.CollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.GetAllAsync());

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.CollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task GetAllAsync_ReturnNoProductFromEmptyDatabase()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetAllAsync())
//                .Returns(ProductDataSetup.EmptyCollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.GetAllAsync());

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.EmptyCollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }
//        #endregion 

//        #region GetFeatureProductAsync
//        [Fact]
//        public async Task GetFeatureProductAsync_ReturnTopProductFromDatabase()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetFeatureProductAsync()).Returns(ProductDataSetup.CollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.GetFeatureProductAsync());

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.CollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task GetFeatureProductAsync_ReturnNoProductFromEmptyDatabase()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetFeatureProductAsync())
//                .Returns(ProductDataSetup.EmptyCollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.GetFeatureProductAsync());

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.EmptyCollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }
//        #endregion

//        #region GetPageCountAsync
//        [Fact]
//        public async Task GetPageCountAsync_ReturnPageCount()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetPageCountAsync())
//                .Returns(Task.FromResult(1));
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<int>(
//                await controller.GetPageCountAsync());

//            string expectedResult = "1";

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }
//        #endregion

//        #region GetByPageAsync
//        [Fact]
//        public async Task GetByPageAsync_ReturnProductFromDatabase()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetProductByPageAsync(1))
//                .Returns(ProductDataSetup.CollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.GetByPageAsync(1));

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.CollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task GetByPageAsync_ReturnNoProduct()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetProductByPageAsync(1))
//                .Returns(ProductDataSetup.EmptyCollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.GetByPageAsync(1));

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.EmptyCollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }
//        #endregion

//        #region GetProductByIdAsync
//        [Fact]
//        public async Task GetProductByIdAsync_ReturnSingleProductFromDatabase()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetProductByIdAsync(1)).Returns(ProductDataSetup.ProductModel());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<ProductModel>(
//                await controller.GetProductByIdAsync(1));

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.ProductModel());
//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task GetProductByIdAsync_ReturnNoProduct()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetProductByIdAsync(0))
//                .Returns<ProductModel>(null);
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var actualResult = await controller.GetProductByIdAsync(0);

//            // Assert
//            actualResult.Should().BeOfType<NoContentResult>();
//        }
//        #endregion 

//        #region GetProductByCategoryAsync
//        [Fact]
//        public async Task GetProductByCategoryAsync_ReturnProductListFromDatabase()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetProductByCategoryAsync(1))
//                .Returns(ProductDataSetup.CollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.GetProductByCategoryAsync(1));

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.CollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task GetProductByCategoryAsync_ReturnEmptyProductList()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetProductByCategoryAsync(0))
//                .Returns(ProductDataSetup.EmptyCollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.GetProductByCategoryAsync(0));

//            var expectedResult = JsonConvert.SerializeObject(await ProductDataSetup.EmptyCollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }
//        #endregion 

//        #region GetProductByNameAsync
//        [Fact]
//        public async Task GetProductByNameAsync_ReturnProductListFromDatabase()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetProductByNameAsync("1"))
//                .Returns(ProductDataSetup.CollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.GetProductByNameAsync("1"));

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.CollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task GetProductByNameAsync_ReturnEmptyProductList()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.GetProductByNameAsync("hahaha"))
//                .Returns(ProductDataSetup.EmptyCollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.GetProductByNameAsync("hahaha"));

//            var expectedResult = JsonConvert.SerializeObject(await ProductDataSetup.EmptyCollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }
//        #endregion 

//        #region FilterProductAsync
//        [Fact]
//        public async Task FilterProductAsync_ReturnProductListFromDatabase()
//        {
//            // Arrange
//            FilterProductModel filter = new FilterProductModel();
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.FilterProductAsync(filter))
//                .Returns(ProductDataSetup.CollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.FilterProductAsync(filter));

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.CollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task FilterProductAsync_ReturnEmptyProductList()
//        {
//            // Arrange
//            FilterProductModel filter = new FilterProductModel();
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.FilterProductAsync(filter))
//                .Returns(ProductDataSetup.EmptyCollectionAsync());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<List<ProductModel>>(
//                await controller.FilterProductAsync(filter));

//            var expectedResult = JsonConvert.SerializeObject(await ProductDataSetup.EmptyCollectionAsync());

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }
//        #endregion 

//        #region DeleteProductAsync
//        [Fact]
//        public async Task DeleteProductAsync_Success_ReturnDeletetedProductId()
//        {
//            // Arrange
//            FilterProductModel filter = new FilterProductModel();
//            var mock = new Mock<IProductRepository>();
            
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<int>(
//                await controller.DeleteProductAsync(1));

//            string expectedResult = "1";

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task DeleteProductAsync_Fail_ReturnNotFoundStatusCode()
//        {
//            // Arrange
//            FilterProductModel filter = new FilterProductModel();
//            var mock = new Mock<IProductRepository>();
//            mock.Setup(m => m.DeleteProductAsync(0))
//                .Throws(new Exception("haha"));
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = await controller.DeleteProductAsync(0);

//            // Assert
//            result.Should().BeOfType<NotFoundObjectResult>();
//        }
//        #endregion 

//        #region UpdateProductAsync
//        [Fact]
//        public async Task UpdateProductAsync_Success_ReturnUpdatedProduct()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            ProductModel productModel = await ProductDataSetup.ProductModel();
//            mock.Setup(m => m.UpdateProductAsync(productModel))
//                .Returns(ProductDataSetup.ProductModel());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<ProductModel>(
//                await controller.UpdateProductAsync(productModel));

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.ProductModel());
//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task UpdateProductAsync_Fail_ReturnBadRequestStatusCode()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            ProductModel productModel = await ProductDataSetup.ProductModel();
//            mock.Setup(m => m.UpdateProductAsync(productModel))
//                .Throws(new Exception("blabla"));
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var actualResult = await controller.UpdateProductAsync(productModel);

//            // Assert
//            actualResult.Should().BeOfType<BadRequestObjectResult>();
//        }
//        #endregion 

//        #region AddProductAsync
//        [Fact]
//        public async Task AddProductAsync_Success_ReturnUpdatedProduct()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            ProductModel productModel = await ProductDataSetup.ProductModel();
//            mock.Setup(m => m.AddProductAsync(productModel))
//                .Returns(ProductDataSetup.ProductModel());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var result = ConvertOkObject<ProductModel>(
//                await controller.AddProductAsync(productModel));

//            string expectedResult = JsonConvert
//                .SerializeObject(await ProductDataSetup.ProductModel());
//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task AddProductAsync_Fail_ReturnBadRequestStatusCode()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            ProductModel productModel = await ProductDataSetup.ProductModel();
//            mock.Setup(m => m.AddProductAsync(productModel))
//                .Throws(new Exception("blabla"));
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var actualResult = await controller.AddProductAsync(productModel);

//            // Assert
//            actualResult.Should().BeOfType<BadRequestObjectResult>();
//        }

//        [Fact]
//        public async Task AddProductAsync_LackImage_ReturnBadRequestStatusCode()
//        {
//            // Arrange
//            var mock = new Mock<IProductRepository>();
//            ProductModel productModel = await ProductDataSetup.ProductModelWithoutImage();
//            mock.Setup(m => m.AddProductAsync(productModel))
//                .Returns(ProductDataSetup.ProductModelWithoutImage());
//            ProductController controller = new ProductController(mock.Object);

//            // Act
//            var actualResult = await controller.AddProductAsync(productModel);

//            // Assert
//            actualResult.Should().BeOfType<BadRequestObjectResult>();
//        }
//        #endregion

//        //#region CheckBuyerAsync
//        //public async Task CheckBuyerAsync
//        //#endregion
//    }
//}
