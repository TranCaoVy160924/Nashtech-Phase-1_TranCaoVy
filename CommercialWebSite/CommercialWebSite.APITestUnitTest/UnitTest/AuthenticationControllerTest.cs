//using CommercialWebSite.API.Controllers;
//using CommercialWebSite.APITestUnitTest.DataSetup;
//using CommercialWebSite.Data.DataModel;
//using CommercialWebSite.DataRepositoryInterface;
//using CommercialWebSite.ShareDTO.Auth;
//using FluentAssertions;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Moq;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using static CommercialWebSite.APITestUnitTest.TestHelper.ConverterFromIActionResult;

//namespace CommercialWebSite.APITestUnitTest.UnitTest
//{
//    public class AuthenticationControllerTest
//    {
//        // Common response
//        private static StatusResponse ExistedUserError = new StatusResponse
//        {
//            Status = "Error",
//            Message = "User already exists!"
//        };
//        private static StatusResponse CreateUserFailed = new StatusResponse
//        {
//            Status = "Error",
//            Message = "User creation failed! "
//                + "Please check user details and try again."
//        };
//        private static StatusResponse CreateUserSucceeded = new StatusResponse
//        {
//            Status = "Success",
//            Message = "User created successfully!"
//        };
//        private static StatusResponse UpdateFailed = new StatusResponse
//        {
//            Status = "Error",
//            Message = "Update user failed"
//        };

//        // Example test user
//        RegisterRequestModel userRegister = new RegisterRequestModel
//        {
//            Username = "user1",
//            Password = "M0unt1210@",
//            Email = "user@gmail.com",
//        };

//        LoginRequestModel userLogin = new LoginRequestModel
//        {
//            Username = "user1",
//            Password = "M0unt1210@"
//        };

//        #region Register
//        [Fact]
//        public async Task Register_ValidRequest_ReturnSucceedStatusResponse()
//        {
//            // Arrange
//            var mock = new Mock<IAuthenticationRepository<UserAccount>>();
//            mock.Setup(
//                m => m.IsExistedAsync(userRegister.Username)).Returns(Task.FromResult(false));
//            mock.Setup(
//                m => m.RegisterNewUserAsync(
//                    userRegister.Username, userRegister.Email, userRegister.Password))
//                .Returns(AuthDataSetup.UserAccountAsync());
//            AuthenticateController controller =
//                new AuthenticateController(null, null, null, mock.Object);

//            // Act
//            string result = ConvertOkObject<StatusResponse>(
//                await controller.RegisterAsync(userRegister));

//            string expectedResult = JsonConvert.SerializeObject(CreateUserSucceeded);

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task Register_UserExisted_ReturnExistedUserResponse()
//        {
//            // Arrange
//            var mock = new Mock<IAuthenticationRepository<UserAccount>>();
//            mock.Setup(
//                m => m.IsExistedAsync(userRegister.Username))
//                .Returns(Task.FromResult(true));
//            mock.Setup(
//                m => m.RegisterNewUserAsync(
//                    userRegister.Username, userRegister.Email, userRegister.Password))
//                .Returns(AuthDataSetup.UserAccountAsync());
//            AuthenticateController controller =
//                new AuthenticateController(null, null, null, mock.Object);

//            // Act
//            string result = ConvertStatusCode(
//                await controller.RegisterAsync(userRegister));

//            string expectedResult = JsonConvert.SerializeObject(ExistedUserError);

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task Register_BadRequest_ReturnCreateUserFailedResponse()
//        {
//            // Arrange
//            var mock = new Mock<IAuthenticationRepository<UserAccount>>();
//            mock.Setup(
//                m => m.IsExistedAsync(userRegister.Username))
//                .Returns(Task.FromResult(false));
//            mock.Setup(
//                m => m.RegisterNewUserAsync(
//                    userRegister.Username, userRegister.Email, userRegister.Password))
//                .Returns<IdentityUser>(null);
//            AuthenticateController controller =
//                new AuthenticateController(null, null, null, mock.Object);

//            // Act
//            string result = ConvertStatusCode(
//                await controller.RegisterAsync(userRegister));

//            string expectedResult = JsonConvert.SerializeObject(CreateUserFailed);

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }
//        #endregion

//        #region Login
//        [Fact]
//        public async Task Login_ValidRequest_LoginSuccessReturnJwtToken()
//        {
//            // Arrange
//            IConfiguration config = InitConfiguration();
//            var mock = new Mock<IAuthenticationRepository<UserAccount>>();
//            mock.Setup(
//                m => m.AuthenticateLoginAsync(userLogin.Username, userLogin.Password))
//                .Returns(AuthDataSetup.GetClaimAsync());
//            AuthenticateController controller =
//                new AuthenticateController(null, null, config, mock.Object);

//            // Act
//            var result = await controller.LoginAsync(userLogin);

//            // Assert
//            result.Should().BeOfType<OkObjectResult>();
//        }

//        [Fact]
//        public async Task Login_InvalidRequest_ReturnUnauthorize()
//        {
//            // Arrange
//            IConfiguration config = InitConfiguration();
//            var mock = new Mock<IAuthenticationRepository<UserAccount>>();
//            mock.Setup(
//                m => m.AuthenticateLoginAsync(userLogin.Username, userLogin.Password))
//                .Returns<List<Claim>>(null);
//            AuthenticateController controller =
//                new AuthenticateController(null, null, config, mock.Object);

//            // Act
//            var result = await controller.LoginAsync(userLogin);

//            // Assert
//            result.Should().BeOfType<UnauthorizedResult>();
//        }
//        #endregion

//        #region RegisterAdminAsync
//        [Fact]
//        public async Task RegisterAdminAsync_Success_ReturnAdminAccount()
//        {
//            // Arrange
//            UserAccount user = await AuthDataSetup.UserAccountAsync();
//            var mock = new Mock<IAuthenticationRepository<UserAccount>>();
//            mock.Setup(
//                m => m.MakeAdmin("1"))
//                .Returns(Task.FromResult(user));
//            mock.Setup(
//                m => m.AddRoleToUserAsync(
//                    user, UserRoles.Admin));
//            mock.Setup(
//                m => m.AddRoleToUserAsync(
//                    user, UserRoles.User));
//            AuthenticateController controller =
//                new AuthenticateController(null, null, null, mock.Object);

//            // Act
//            string result = ConvertOkObject<UserAccount>(
//                await controller.RegisterAdminAsync("1"));

//            string expectedResult = JsonConvert.SerializeObject(user);

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task RegisterAdminAsync_FailToUpdateUserRole_ReturnErrorStatusCode()
//        {
//            // Arrange
//            UserAccount user = await AuthDataSetup.UserAccountAsync();
//            var mock = new Mock<IAuthenticationRepository<UserAccount>>();
//            mock.Setup(
//                m => m.MakeAdmin("1"))
//                .Throws(new Exception("dsfasdf"));
//            mock.Setup(
//                m => m.AddRoleToUserAsync(
//                    user, UserRoles.Admin));
//            mock.Setup(
//                m => m.AddRoleToUserAsync(
//                    user, UserRoles.User));
//            AuthenticateController controller =
//                new AuthenticateController(null, null, null, mock.Object);

//            // Act
//            string result = ConvertStatusCode(
//                await controller.RegisterAdminAsync("1"));

//            string expectedResult = JsonConvert.SerializeObject(UpdateFailed);

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task RegisterAdminAsync_FailToAddRoleAdmin_ReturnErrorStatusCode()
//        {
//            // Arrange
//            UserAccount user = await AuthDataSetup.UserAccountAsync();
//            var mock = new Mock<IAuthenticationRepository<UserAccount>>();
//            mock.Setup(
//                m => m.MakeAdmin("1"))
//                .Returns(Task.FromResult(user));
//            mock.Setup(
//                m => m.AddRoleToUserAsync(
//                    user, UserRoles.Admin))
//                .Throws(new Exception("sdfasdfa"));
//            mock.Setup(
//                m => m.AddRoleToUserAsync(
//                    user, UserRoles.User));
//            AuthenticateController controller =
//                new AuthenticateController(null, null, null, mock.Object);

//            // Act
//            string result = ConvertStatusCode(
//                await controller.RegisterAdminAsync("1"));

//            string expectedResult = JsonConvert.SerializeObject(UpdateFailed);

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }

//        [Fact]
//        public async Task RegisterAdminAsync_FailToAddRoleUser_ReturnErrorStatusCode()
//        {
//            // Arrange
//            UserAccount user = await AuthDataSetup.UserAccountAsync();
//            var mock = new Mock<IAuthenticationRepository<UserAccount>>();
//            mock.Setup(
//                m => m.MakeAdmin("1"))
//                .Returns(Task.FromResult(user));
//            mock.Setup(
//                m => m.AddRoleToUserAsync(
//                    user, UserRoles.Admin));
//            mock.Setup(
//                m => m.AddRoleToUserAsync(
//                    user, UserRoles.User))
//            .Throws(new Exception("sdfasdfa"));
//            AuthenticateController controller =
//                new AuthenticateController(null, null, null, mock.Object);

//            // Act
//            string result = ConvertStatusCode(
//                await controller.RegisterAdminAsync("1"));

//            string expectedResult = JsonConvert.SerializeObject(UpdateFailed);

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }
//        #endregion

//        #region CheckTokenAsync
//        [Fact]
//        public async Task CheckTokenAsync_ReturnOkWhenTokenIsValid()
//        {
//            // Arrange
//            AuthenticateController controller =
//                new AuthenticateController(null, null, null, null);

//            // Act
//            string result = ConvertOkObject<bool>(
//                await controller.CheckTokenAsync());

//            string expectedResult = JsonConvert.SerializeObject(true);

//            // Assert
//            Assert.Equal(expectedResult, result);
//        }
//        #endregion

//        public static IConfiguration InitConfiguration()
//        {
//            var config = new ConfigurationBuilder()
//               .AddJsonFile("appsettings.json")
//                .AddEnvironmentVariables()
//                .Build();
//            return config;
//        }
//    }
//}
