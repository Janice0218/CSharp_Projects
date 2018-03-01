using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restauranter.Models
{
    public class Restaurant
    {
        [Key]
        public int restaurant_id { get; set; }
        public int rating { get; set; }
        public string restaurant_name { get; set; }
        public string reviewer_name { get; set; }
        [UIHint("Date")]
        public DateTime visit_date { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
        public string review { get; set; }
    }
}
