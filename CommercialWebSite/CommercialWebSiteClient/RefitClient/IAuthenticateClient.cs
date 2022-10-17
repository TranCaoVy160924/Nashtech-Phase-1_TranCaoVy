using Refit;
//using CommercialWebSiteClient.Models;
using AuthModels.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CommercialWebSiteClient.RefitClient
{
    public interface IAuthenticateClient
    {
        [Post("/Authenticate/Register")]
        Task Register([Body] RegisterRequestModel model);
    }
}
