using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotingDojo.Models
{
    public class User
    {
        public string name { get; set; }
        public string quote { get; set; }
        public string created_at { get; } 
    }
}
