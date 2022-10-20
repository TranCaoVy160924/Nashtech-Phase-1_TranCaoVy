using System.ComponentModel.DataAnnotations;

namespace CommercialWebSite.ShareDTO.Auth
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
