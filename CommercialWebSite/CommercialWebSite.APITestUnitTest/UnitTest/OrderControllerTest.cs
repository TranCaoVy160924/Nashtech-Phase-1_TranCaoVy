using CommercialWebSite.API.Controllers;
using CommercialWebSite.APITestUnitTest.DataSetup;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static CommercialWebSite.APITestUnitTest.DataSetup.AuthDataSetup;
using static CommercialWebSite.APITestUnitTest.TestHelper.ConverterFromIActionResult;

namespace CommercialWebSite.APITestUnitTest.UnitTest
{
    public class OrderControllerTest
    {
        #region GetByBuyerIdAsync
        [Fact]
        public async Task GetByBuyerIdAsync_ReturnOrderList()
        {
            // Arrange
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(m => m.GetByBuyerIdAsync("1"))
                .Returns(Task.FromResult(OrderDataSetup.Collection()));
            OrderController controller = new OrderController(repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = ConvertOkObject<List<OrderModel>>(
                await controller.GetByBuyerIdAsync("1"));

            string expectedResult = JsonConvert
                .SerializeObject(OrderDataSetup.Collection());

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion 

        #region IncreOrderProductNumAsync
        [Fact]
        public async Task IncreOrderProductNumAsync_Success_ReturnUpdatedOrder()
        {
            // Arrange
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(m => m.IncreaseProductNumAsync(1))
                .Returns(Task.FromResult(OrderDataSetup.SingleObject()));
            OrderController controller = new OrderController(repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = ConvertOkObject<OrderModel>(
                await controller.IncreOrderProductNumAsync(1));

            string expectedResult = JsonConvert
                .SerializeObject(OrderDataSetup.SingleObject());

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IncreOrderProductNumAsync_NotFoundOrder_ReturnNotFound()
        {
            // Arrange
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(m => m.IncreaseProductNumAsync(1))
                .Throws(new Exception("haha"));
            OrderController controller = new OrderController(repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = await controller.IncreOrderProductNumAsync(1);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }
        #endregion 

        #region SubOrderProductNumAsync
        [Fact]
        public async Task SubOrderProductNumAsync_Success_ReturnUpdatedOrder()
        {
            // Arrange
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(m => m.SubProductNumAsync(1))
                .Returns(Task.FromResult(OrderDataSetup.SingleObject()));
            OrderController controller = new OrderController(repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = ConvertOkObject<OrderModel>(
                await controller.SubOrderProductNumAsync(1));

            string expectedResult = JsonConvert
                .SerializeObject(OrderDataSetup.SingleObject());

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SubOrderProductNumAsync_NotFoundOrder_ReturnNotFound()
        {
            // Arrange
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(m => m.SubProductNumAsync(1))
                .Throws(new Exception("haha"));
            OrderController controller = new OrderController(repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = await controller.SubOrderProductNumAsync(1);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }
        #endregion

        #region CreateOrderAsync
        [Fact]
        public async Task CreateOrderAsync_Success_ReturnNewOrder()
        {
            // Arrange
            var newOrder = OrderDataSetup.SingleObject();
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(m => m.CreateOrderAsync(newOrder))
                .Returns(Task.FromResult(OrderDataSetup.SingleObject()));
            OrderController controller = new OrderController(repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = ConvertOkObject<OrderModel>(
                await controller.CreateOrderAsync(newOrder));

            string expectedResult = JsonConvert
                .SerializeObject(OrderDataSetup.SingleObject());

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CreateOrderAsync_Failed_ReturnBadRequest()
        {
            // Arrange
            var newOrder = OrderDataSetup.SingleObject();
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(m => m.CreateOrderAsync(newOrder))
                .Throws(new Exception("haha"));
            OrderController controller = new OrderController(repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = await controller
                .CreateOrderAsync(newOrder);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        #endregion

        #region CheckoutAsync
        [Fact]
        public async Task CheckoutAsync_Success_ReturnOk()
        {
            // Arrange
            var checkingOutOrderIds = new List<int>();
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(m => m.CheckoutAsync(checkingOutOrderIds));
            OrderController controller = new OrderController(repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = JsonConvert.SerializeObject(
                await controller.CheckoutAsync(checkingOutOrderIds));

            string expectedResult = JsonConvert
                .SerializeObject(new StatusCodeResult(StatusCodes.Status200OK));

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CheckoutAsync_Failed_ReturnBadRequest()
        {
            // Arrange
            var checkingOutOrderIds = new List<int>();
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(m => m.CheckoutAsync(checkingOutOrderIds))
                .Throws(new Exception("haha"));
            OrderController controller = new OrderController(repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = await controller
                .CheckoutAsync(checkingOutOrderIds);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        #endregion

        #region CancelOrderAsync
        [Fact]
        public async Task CancelOrderAsync_Success_ReturnOk()
        {
            // Arrange
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(m => m.DeleteOrderAsync(1))
                .Returns(Task.FromResult(OrderDataSetup.SingleObject()));
            OrderController controller = new OrderController(repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = JsonConvert.SerializeObject(
                await controller.CancelOrderAsync(1));

            string expectedResult = JsonConvert
                .SerializeObject(new StatusCodeResult(StatusCodes.Status200OK));

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CancelOrderAsync_Failed_ReturnBadRequest()
        {
            // Arrange
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(m => m.DeleteOrderAsync(1))
                .Throws(new Exception("haha"));
            OrderController controller = new OrderController(repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = await controller
                .CancelOrderAsync(1);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        #endregion
    }
}
