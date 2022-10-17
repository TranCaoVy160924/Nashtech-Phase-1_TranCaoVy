using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CommercialWebSiteClient.Models
{
    public class RegisterRequestModel
    {
        [JsonProperty(PropertyName = "username")]
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [JsonProperty(PropertyName = "email")]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
