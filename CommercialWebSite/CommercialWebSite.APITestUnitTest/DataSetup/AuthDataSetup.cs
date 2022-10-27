﻿using CommercialWebSite.Data.DataModel;
using Microsoft.AspNetCore.Identity;
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

        public static Object GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr"));

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:4200",
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }

        public static async Task<List<Claim>> GetClaimAsync()
        {
            var claims = new List<Claim>();
            return claims;
        }
    }
}
