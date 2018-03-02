using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccounts.Models
{
    public class Transaction
    {
        [Key]
        public int transaction_id { get; set; }
        public string type { get; set; }
        public decimal amount { get; set; }
        public DateTime timestamp { get; set; }
        public int Users_user_id { get; set; }


    }
}
