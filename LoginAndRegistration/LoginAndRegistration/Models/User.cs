using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAndRegistration.Models
{
    public class User
    {
        [Required(ErrorMessage = "Enter your first name")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "first name must be letters only")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must be letters only")]
        public string last_name { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        [EmailAddress(ErrorMessage ="Enter a valid email address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters")]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Passwords do not match")]
        public string password2 { get; set; }
    }

    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
