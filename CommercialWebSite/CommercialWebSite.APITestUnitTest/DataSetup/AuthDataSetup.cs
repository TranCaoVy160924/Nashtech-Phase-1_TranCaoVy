using CommercialWebSite.Data.DataModel;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.APITestUnitTest.DataSetup
{
    public static class AuthDataSetup
    {
        public static async Task<UserAccount> UserAccountAsync()
        {
            UserAccount user = new UserAccount
            {
                Id = "257b61be-ccbd-452e-be18-cc235c3cc083",
                Email = "1@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "cong ga",
                FirstName = "asdsa",
                LastName = "dsfdsfsd",
                Birthday = DateTime.Today,
                UserAddress = "dsfdsfa"
            };

            return user;
        }

        public static async Task<List<UserAccountModel>> ModelCollectionAsync()
        {
            List<UserAccountModel> userAccounts = new List<UserAccountModel>();
            userAccounts.Add(new UserAccountModel
            {
                Id = "257b61be-ccbd-452e-be18-cc235c3cc083",
                FirstName = "asdsa",
                LastName = "dsfdsfsd",
                Birthday = DateTime.Today,
                UserAddress = "dsfdsfa"
            });
            return userAccounts;
        }

        public static async Task<List<UserAccountModel>> EmptyModelCollectionAsync()
        {
            List<UserAccountModel> userAccounts = new List<UserAccountModel>();
            return userAccounts;
        }

        public static async Task<List<Claim>> GetClaimAsync()
        {
            var claims = new List<Claim>();
            return claims;
        }

        public static void SetUpContextValidToken(ControllerBase controller)
        {
            CreateContext(controller);
            controller.ControllerContext.HttpContext.Items["isValidToken"] = true;
        }

        public static void SetUpContextInvalidToken(ControllerBase controller)
        {
            CreateContext(controller);
            controller.ControllerContext.HttpContext.Items["isValidToken"] = false;
        }

        public static void SetUpAuthHeader(ControllerBase controller)
        {
            CreateContext(controller);
            controller.ControllerContext.HttpContext.Request.Headers["Authorization"] = "abcxyz";
        }

        private static void CreateContext(ControllerBase controller)
        {
            if (controller.ControllerContext.HttpContext == null)
            {
                controller.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                };
            }
        } 
    }
}
