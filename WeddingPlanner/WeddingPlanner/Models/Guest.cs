using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingPlanner.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string AFirstName { get; set; }
        public string ALastName { get; set; }
        public string BFirstName { get; set; }
        public string BLastName { get; set; }
        public bool? IsAttending { get; set; }
        public int WeddingId { get; set; }
        
        
    }
}
