using CommercialWebSite.API.AuthHelper;
using CommercialWebSite.API.Controllers;
using CommercialWebSite.APITestUnitTest.DataSetup;
using CommercialWebSite.Data.DataModel;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Auth;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
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
using static CommercialWebSite.APITestUnitTest.DataSetup.AuthDataSetup;

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
        private static StatusResponse UpdateFailed = new StatusResponse
        {
            Status = "Error",
            Message = "Update user failed"
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
            var repoMock = new Mock<IAuthenticationRepository<UserAccount>>();
            repoMock.Setup(
                m => m.IsExistedAsync(userRegister.Username)).Returns(Task.FromResult(false));
            repoMock.Setup(
                m => m.RegisterNewUserAsync(
                    userRegister.Username, userRegister.Email, userRegister.Password))
                .Returns(AuthDataSetup.UserAccountAsync());
            AuthenticateController controller =
                new AuthenticateController(null, null, null, null, repoMock.Object);

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
            var repoMock = new Mock<IAuthenticationRepository<UserAccount>>();
            repoMock.Setup(
                m => m.IsExistedAsync(userRegister.Username))
                .Returns(Task.FromResult(true));
            repoMock.Setup(
                m => m.RegisterNewUserAsync(
                    userRegister.Username, userRegister.Email, userRegister.Password))
                .Returns(AuthDataSetup.UserAccountAsync());
            AuthenticateController controller =
                new AuthenticateController(null, null, null, null, repoMock.Object);

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
            var repoMock = new Mock<IAuthenticationRepository<UserAccount>>();
            repoMock.Setup(
                m => m.IsExistedAsync(userRegister.Username))
                .Returns(Task.FromResult(false));
            repoMock.Setup(
                m => m.RegisterNewUserAsync(
                    userRegister.Username, userRegister.Email, userRegister.Password))
                .Returns<IdentityUser>(null);
            AuthenticateController controller =
                new AuthenticateController(null, null, null, null, repoMock.Object);

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
            var repoMock = new Mock<IAuthenticationRepository<UserAccount>>();
            repoMock.Setup(
                m => m.AuthenticateLoginAsync(userLogin.Username, userLogin.Password))
                .Returns(AuthDataSetup.GetClaimAsync());

            var jwtManagerMock = new Mock<ITokenManager>();
            jwtManagerMock.Setup(
                m => m.AddToken("abcxyz"));

            AuthenticateController controller =
                new AuthenticateController(null, null, config, 
                    jwtManagerMock.Object, repoMock.Object);

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
            var repoMock = new Mock<IAuthenticationRepository<UserAccount>>();
            repoMock.Setup(
                m => m.AuthenticateLoginAsync(userLogin.Username, userLogin.Password))
                .Returns<List<Claim>>(null);

            var jwtManagerMock = new Mock<ITokenManager>();
            jwtManagerMock.Setup(
                m => m.AddToken("abcxyz"));

            AuthenticateController controller =
                new AuthenticateController(null, null, config, 
                    jwtManagerMock.Object, repoMock.Object);

            // Act
            var result = await controller.LoginAsync(userLogin);

            // Assert
            result.Should().BeOfType<UnauthorizedResult>();
        }
        #endregion

        #region LogoutAsync
        [Fact]
        public async Task LogoutAsync_ValidToken_Logout()
        {
            // Arrange
            IConfiguration config = InitConfiguration();

            var jwtManagerMock = new Mock<ITokenManager>();
            jwtManagerMock.Setup(m => m.IsValid("abcxyz"))
                .Returns(true);
            jwtManagerMock.Setup(m => m.DeleteToken("abcxyz"));

            AuthenticateController controller =
                new AuthenticateController(null, null, null,
                    jwtManagerMock.Object, null);
            SetUpAuthHeader(controller);

            // Act
            var result = await controller.LogoutAsync();

            // Assert
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task LogoutAsync_InValidToken_ReturnUnauthorizedStatusCode()
        {
            // Arrange
            IConfiguration config = InitConfiguration();

            var jwtManagerMock = new Mock<ITokenManager>();
            jwtManagerMock.Setup(m => m.IsValid("abcxyz"))
                .Returns(false);
            jwtManagerMock.Setup(m => m.DeleteToken("abcxyz"));

            AuthenticateController controller =
                new AuthenticateController(null, null, null,
                    jwtManagerMock.Object, null);
            SetUpAuthHeader(controller);

            // Act
            var result = await controller.LogoutAsync();

            // Assert
            result.Should().BeOfType<UnauthorizedResult>();
        }
        #endregion

        #region RegisterAdminAsync
        [Fact]
        public async Task RegisterAdminAsync_Success_ReturnAdminAccount()
        {
            // Arrange
            UserAccount user = await AuthDataSetup.UserAccountAsync();
            var repoMock = new Mock<IAuthenticationRepository<UserAccount>>();
            repoMock.Setup(
                m => m.MakeAdmin("1"))
                .Returns(Task.FromResult(user));
            repoMock.Setup(
                m => m.AddRoleToUserAsync(
                    user, UserRoles.Admin));
            repoMock.Setup(
                m => m.AddRoleToUserAsync(
                    user, UserRoles.User));
            AuthenticateController controller =
                new AuthenticateController(null, null, null, null, repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            string result = ConvertOkObject<UserAccount>(
                await controller.RegisterAdminAsync("1"));

            string expectedResult = JsonConvert.SerializeObject(user);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task RegisterAdminAsync_FailToUpdateUserRole_ReturnErrorStatusCode()
        {
            // Arrange
            UserAccount user = await AuthDataSetup.UserAccountAsync();
            var repoMock = new Mock<IAuthenticationRepository<UserAccount>>();
            repoMock.Setup(
                m => m.MakeAdmin("1"))
                .Throws(new Exception("dsfasdf"));
            repoMock.Setup(
                m => m.AddRoleToUserAsync(
                    user, UserRoles.Admin));
            repoMock.Setup(
                m => m.AddRoleToUserAsync(
                    user, UserRoles.User));
            AuthenticateController controller =
                new AuthenticateController(null, null, null, null, repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            string result = ConvertStatusCode(
                await controller.RegisterAdminAsync("1"));

            string expectedResult = JsonConvert.SerializeObject(UpdateFailed);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task RegisterAdminAsync_FailToAddRoleAdmin_ReturnErrorStatusCode()
        {
            // Arrange
            UserAccount user = await AuthDataSetup.UserAccountAsync();
            var repoMock = new Mock<IAuthenticationRepository<UserAccount>>();
            repoMock.Setup(
                m => m.MakeAdmin("1"))
                .Returns(Task.FromResult(user));
            repoMock.Setup(
                m => m.AddRoleToUserAsync(
                    user, UserRoles.Admin))
                .Throws(new Exception("sdfasdfa"));
            repoMock.Setup(
                m => m.AddRoleToUserAsync(
                    user, UserRoles.User));
            AuthenticateController controller =
                new AuthenticateController(null, null, null, null, repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            string result = ConvertStatusCode(
                await controller.RegisterAdminAsync("1"));

            string expectedResult = JsonConvert.SerializeObject(UpdateFailed);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task RegisterAdminAsync_FailToAddRoleUser_ReturnErrorStatusCode()
        {
            // Arrange
            UserAccount user = await AuthDataSetup.UserAccountAsync();
            var repoMock = new Mock<IAuthenticationRepository<UserAccount>>();
            repoMock.Setup(
                m => m.MakeAdmin("1"))
                .Returns(Task.FromResult(user));
            repoMock.Setup(
                m => m.AddRoleToUserAsync(
                    user, UserRoles.Admin));
            repoMock.Setup(
                m => m.AddRoleToUserAsync(
                    user, UserRoles.User))
            .Throws(new Exception("sdfasdfa"));
            AuthenticateController controller =
                new AuthenticateController(null, null, null, null, repoMock.Object);
            SetUpContextValidToken(controller);

            // Act
            string result = ConvertStatusCode(
                await controller.RegisterAdminAsync("1"));

            string expectedResult = JsonConvert.SerializeObject(UpdateFailed);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task RegisterAdminAsync_InvalidToken_ReturnUnauthorized()
        {
            // Arrange
            UserAccount user = await AuthDataSetup.UserAccountAsync();
            var repoMock = new Mock<IAuthenticationRepository<UserAccount>>();
            repoMock.Setup(
                m => m.MakeAdmin("1"))
                .Returns(Task.FromResult(user));
            repoMock.Setup(
                m => m.AddRoleToUserAsync(
                    user, UserRoles.Admin));
            repoMock.Setup(
                m => m.AddRoleToUserAsync(
                    user, UserRoles.User))
            .Throws(new Exception("sdfasdfa"));
            AuthenticateController controller =
                new AuthenticateController(null, null, null, null, repoMock.Object);
            SetUpContextInvalidToken(controller);

            // Act
            var result = await controller.RegisterAdminAsync("1");

            // Assert
            result.Should().BeOfType<UnauthorizedResult>();
        }
        #endregion

        #region CheckTokenAsync
        [Fact]
        public async Task CheckTokenAsync_ReturnOkWhenTokenIsValid()
        {
            // Arrange
            AuthenticateController controller =
                new AuthenticateController(null, null, null, null, null);
            SetUpContextValidToken(controller);

            // Act
            string result = ConvertOkObject<bool>(
                await controller.CheckTokenAsync());

            string expectedResult = JsonConvert.SerializeObject(true);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CheckTokenAsync_InvalidToken_ReturnUnauthorized()
        {
            // Arrange
            AuthenticateController controller =
                new AuthenticateController(null, null, null, null, null);
            SetUpContextInvalidToken(controller);

            // Act
            var result = await controller.CheckTokenAsync();

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
