using Refit;
//using CommercialWebSiteClient.Models;
using CommercialWebSite.ShareDTO.Auth;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CommercialWebSite.Client.RefitClient
{
    public interface IAuthenticateClient
    {
        [Post("/Authenticate/Register")]
        Task Register([Body] RegisterRequestModel model);

        [Post("/Authenticate/Login")]
        Task<string> Login([Body] LoginRequestModel model);
    }
}
