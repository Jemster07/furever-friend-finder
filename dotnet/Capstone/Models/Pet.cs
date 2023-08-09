using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Capstone.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Type { get; set; }
        public string Species { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }
        public Attribute Attributes { get; set; }
        public Environ Environment { get; set; }
        public Tag Tags { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public int UserId { get; set; }
        public int PhotoId { get; set; }
        public int AdopterId { get; set; }
        public bool IsAdopted { get; set; }
    }
}
