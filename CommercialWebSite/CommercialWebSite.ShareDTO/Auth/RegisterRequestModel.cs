using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CommercialWebSite.ShareDTO.Auth
{
    public class RegisterRequestModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Password must be at least 8 character with " +
            "lower and uppercase, number and special character")]
        public string? Password { get; set; }
    }
}
