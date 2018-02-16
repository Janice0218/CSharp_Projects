using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWall.Models
{
    public class User
    {
        [Required]
        [Display(Name = "first name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter letters only for first name")]
        public string first_name { get; set; }

        [Required]
        [Display(Name = "last name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter letters only for last name")]
        public string last_name { get; set; }

        [Required]
        [Display(Name = "email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "passwords should be a minimum of 8 characters")]
        [Display(Name = "password")]
        public string password { get; set; }

        [Required]
        [Display(Name = "verify password")]
        [Compare("password", ErrorMessage = "Passwords do not match")]
        public string password2 { get; set; }
    }

    public class ReturningUser
    {
        [Required]
        [Display(Name = "email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "password")]
        public string password { get; set; }
    }
}
