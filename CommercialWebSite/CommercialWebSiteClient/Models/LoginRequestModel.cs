using System.ComponentModel.DataAnnotations;

namespace CommercialWebSiteClient.Models
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
