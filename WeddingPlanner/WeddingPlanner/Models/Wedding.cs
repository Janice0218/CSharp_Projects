using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }
        public string AFirstName{ get; set; }
        public string ALastName { get; set; }
        public string BFirstName{ get; set; }
        public string BLastName { get; set; }
        public int UserId { get; set; } = 1;
        public DateTime Date { get; set; }
        public string AddressName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public List<Guest> Guests { get; set; }


    }
}
