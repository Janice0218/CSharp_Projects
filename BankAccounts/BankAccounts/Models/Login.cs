using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccounts.Models
{
    public class Login
    {
        [EmailAddress (ErrorMessage = "Enter a valid email")]
        public string email { get; set; }
        [DataType(DataType.Password)] public string password { get; set; }
    }
}
