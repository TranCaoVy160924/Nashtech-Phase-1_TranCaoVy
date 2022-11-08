using CommercialWebSite.API.Controllers;
using CommercialWebSite.APITestUnitTest.DataSetup;
using CommercialWebSite.Data.DataModel;
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
using static CommercialWebSite.APITestUnitTest.DataSetup.AuthDataSetup;

namespace CommercialWebSite.APITestUnitTest.UnitTest
{
    public class UserControllerTest
    {
        #region GetAllAsync
        [Fact]
        public async Task GetAllAsync_ReturnAllUser()
        {
            // Arrange
            var mock = new Mock<IUserAccountRepository>();
            mock.Setup(m => m.GetAllAsync())
                .Returns(AuthDataSetup.ModelCollectionAsync());
            UserController controller = new UserController(mock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = ConvertOkObject<List<UserAccountModel>>(
                await controller.GetAllAsync());

            string expectedResult = JsonConvert
                .SerializeObject(await AuthDataSetup.ModelCollectionAsync());

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnEmptyUserCollection()
        {
            // Arrange
            var mock = new Mock<IUserAccountRepository>();
            mock.Setup(m => m.GetAllAsync())
                .Returns(AuthDataSetup.EmptyModelCollectionAsync());
            UserController controller = new UserController(mock.Object);
            SetUpContextValidToken(controller);

            // Act
            var result = ConvertOkObject<List<UserAccountModel>>(
                await controller.GetAllAsync());

            string expectedResult = JsonConvert
                .SerializeObject(await AuthDataSetup.EmptyModelCollectionAsync());

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion
    }
}
