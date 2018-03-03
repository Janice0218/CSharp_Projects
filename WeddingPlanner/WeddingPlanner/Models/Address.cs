using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public int WeddingId { get; set; }
    }
}