using CommercialWebSite.API.Controllers;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommercialWebSite.APITestUnitTest.UnitTest
{
    public class ReviewControllerTest
    {
        ProductReviewModel review = new ProductReviewModel
        {
            ProductId = 1,
            ProductRating = 1,
            UserAccountId = "sdfsd",
            UserName = "sdfsdf"
        };

        #region PostReviewAsync
        [Fact]
        public async Task PostReviewAsync_ValidRequest_ReturnCreatedStatucCode()
        {

            // Arrange
            var mock = new Mock<IReviewRepository>();
            mock.Setup(
                m => m.PostReviewAsync(review))
                .Returns(Task.FromResult(true));
            ReviewController controller =
                new ReviewController(mock.Object);

            // Act
            var resultRespsonse = await controller.PostReviewAsync(review);
            var resultStatusCodeObject = (StatusCodeResult)resultRespsonse;
            var result = resultStatusCodeObject.StatusCode;
            var expectedRestult = StatusCodes.Status201Created;
            // Assert
            Assert.Equal(expectedRestult, result);
        }

        [Fact]
        public async Task PostReviewAsync_InValidRequest_ReturnBadRequestStatucCode()
        {

            // Arrange
            var mock = new Mock<IReviewRepository>();
            mock.Setup(
                m => m.PostReviewAsync(review))
                .Returns(Task.FromResult(false));
            ReviewController controller =
                new ReviewController(mock.Object);

            // Act
            var resultRespsonse = await controller.PostReviewAsync(review);
            var resultStatusCodeObject = (StatusCodeResult)resultRespsonse;
            var result = resultStatusCodeObject.StatusCode;
            var expectedRestult = StatusCodes.Status400BadRequest;
            // Assert
            Assert.Equal(expectedRestult, result);
        }
        #endregion
    }
}
