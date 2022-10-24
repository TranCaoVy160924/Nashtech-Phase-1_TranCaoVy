using CommercialWebSite.API.Controllers;
using CommercialWebSite.APITestUnitTest.DataSetup;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Auth;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static CommercialWebSite.APITestUnitTest.TestHelper.ConverterFromIActionResult;

namespace CommercialWebSite.APITestUnitTest.UnitTest
{
    public class AuthenticationControllerTest
    { 
        // Common response
        private static StatusResponse ExistedUserError = new StatusResponse
        {
            Status = "Error",
            Message = "User already exists!"
        };
        private static StatusResponse CreateUserFailed = new StatusResponse
        {
            Status = "Error",
            Message = "User creation failed! "
                + "Please check user details and try again."
        };
        private static StatusResponse CreateUserSucceeded = new StatusResponse
        {
            Status = "Success",
            Message = "User created successfully!"
        };

        // Example test user
        RegisterRequestModel userRegister = new RegisterRequestModel
        {
            Username = "user1",
            Password = "M0unt1210@",
            Email = "user@gmail.com",
        };

        LoginRequestModel userLogin = new LoginRequestModel
        {
            Username = "user1",
            Password = "M0unt1210@"
        };

        #region Register
        [Fact]
        public async Task Register_ValidRequest_ReturnSucceedStatusResponse()
        {
            // Arrange
            var mock = new Mock<IAuthenticationRepository>();
            mock.Setup(
                m => m.IsExistedAsync(userRegister.Username)).Returns(Task.FromResult(false));
            mock.Setup(
                m => m.RegisterNewUserAsync(
                    userRegister.Username, userRegister.Email, userRegister.Password))
                .Returns(AuthDataSetup.UserAccountAsync());
            AuthenticateController controller =
                new AuthenticateController(null, null, null, mock.Object);

            // Act
            string result = ConvertOkObject<StatusResponse>(
                await controller.RegisterAsync(userRegister));

            string expectedResult = JsonConvert.SerializeObject(CreateUserSucceeded);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task Register_UserExisted_ReturnExistedUserResponse()
        {
            // Arrange
            var mock = new Mock<IAuthenticationRepository>();
            mock.Setup(
                m => m.IsExistedAsync(userRegister.Username))
                .Returns(Task.FromResult(true));
            mock.Setup(
                m => m.RegisterNewUserAsync(
                    userRegister.Username, userRegister.Email, userRegister.Password))
                .Returns(AuthDataSetup.UserAccountAsync());
            AuthenticateController controller =
                new AuthenticateController(null, null, null, mock.Object);

            // Act
            string result = ConvertStatusCode(
                await controller.RegisterAsync(userRegister));

            string expectedResult = JsonConvert.SerializeObject(ExistedUserError);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task Register_BadRequest_ReturnCreateUserFailedResponse()
        {
            // Arrange
            var mock = new Mock<IAuthenticationRepository>();
            mock.Setup(
                m => m.IsExistedAsync(userRegister.Username))
                .Returns(Task.FromResult(false));
            mock.Setup(
                m => m.RegisterNewUserAsync(
                    userRegister.Username, userRegister.Email, userRegister.Password))
                .Returns<IdentityUser>(null);
            AuthenticateController controller =
                new AuthenticateController(null, null, null, mock.Object);

            // Act
            string result = ConvertStatusCode(
                await controller.RegisterAsync(userRegister));

            string expectedResult = JsonConvert.SerializeObject(CreateUserFailed);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region Login
        [Fact]
        public async Task Login_ValidRequest_LoginSuccessReturnJwtToken()
        {
            // Arrange
            IConfiguration config = InitConfiguration();
            var mock = new Mock<IAuthenticationRepository>();
            mock.Setup(
                m => m.AuthenticateLoginAsync(userLogin.Username, userLogin.Password))
                .Returns(AuthDataSetup.GetClaimAsync());
            AuthenticateController controller =
                new AuthenticateController(null, null, config, mock.Object);

            // Act
            var result = await controller.LoginAsync(userLogin);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task Login_InvalidRequest_ReturnUnauthorize()
        {
            // Arrange
            IConfiguration config = InitConfiguration();
            var mock = new Mock<IAuthenticationRepository>();
            mock.Setup(
                m => m.AuthenticateLoginAsync(userLogin.Username, userLogin.Password))
                .Returns<List<Claim>>(null);
            AuthenticateController controller =
                new AuthenticateController(null, null, config, mock.Object);

            // Act
            var result = await controller.LoginAsync(userLogin);

            // Assert
            result.Should().BeOfType<UnauthorizedResult>();
        }
        #endregion

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }
    }
}
