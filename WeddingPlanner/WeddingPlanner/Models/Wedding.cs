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
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public List<Address> AddressBook { get; set; } = new List<Address>();
        public List<Guest> GuestList { get; set; } = new List<Guest>();
        
    }
}
