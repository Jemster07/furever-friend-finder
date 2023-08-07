using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Capstone.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string PhotoUrl { get; set; }
        public int PetId { get; set; }
    }
}
