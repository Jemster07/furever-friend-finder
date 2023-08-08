using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Capstone.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public bool IsPlayful { get; set; }
        public bool IsNeedsExercise { get; set; }
        public bool IsCute { get; set; }
        public bool IsAffectionate { get; set; }
        public bool IsLarge { get; set; }
        public bool IsIntelligent { get; set; }
        public bool IsHappy { get; set; }
        public bool IsShortHaired { get; set; }
        public bool IsShedder { get; set; }
        public bool IsShy { get; set; }
        public bool IsFaithful { get; set; }
        public bool IsLeashTrained { get; set; }
        public bool IsHypoallergenic { get; set; }
    }
}
