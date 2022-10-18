using Refit;
//using CommercialWebSiteClient.Models;
using ShareModelsDTO.Auth;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CommercialWebSiteClient.RefitClient
{
    public interface IAuthenticateClient
    {
        [Post("/Authenticate/Register")]
        Task Register([Body] RegisterRequestModel model);

        [Post("/Authenticate/Login")]
        Task<string> Login([Body] LoginRequestModel model);
    }
}
