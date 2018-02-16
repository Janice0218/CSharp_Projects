using System.ComponentModel.DataAnnotations;

namespace LoginAndRegistration.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Enter your email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters")]
        public string password { get; set; }
    }
}
