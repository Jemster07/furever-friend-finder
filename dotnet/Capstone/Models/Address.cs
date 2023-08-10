using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Capstone.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    public class CreateAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        [StringLength(2, ErrorMessage = "State abbreviation should be 2 characters")]
        public string State { get; set; }
        [Range(int.MinValue, int.MaxValue)]
        public string Zip { get; set; }
    }
}
