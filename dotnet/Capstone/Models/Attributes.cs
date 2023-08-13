using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Capstone.Models
{
    public class Attributes
    {
        public int AttributeId { get; set; }
        public bool IsSpayedNeutered { get; set; }
        public bool IsHouseTrained { get; set; }
        public bool IsDeclawed { get; set; }
        public bool IsSpecialNeeds { get; set; }
        public bool IsShotsCurrent { get; set; }
    }
}
