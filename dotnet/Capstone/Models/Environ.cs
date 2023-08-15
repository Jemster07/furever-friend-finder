using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Capstone.Models
{
    public class Environ
    {
        public int EnvironmentId { get; set; }
        public bool IsChildSafe { get; set; }
        public bool IsDogSafe { get; set; }
        public bool IsCatSafe { get; set; }
        public bool IsOtherAnimalSafe { get; set; }
        public bool IsIndoorOnly { get; set; }
    }

    public class NewEnviron
    {
        public bool IsChildSafe { get; set; }
        public bool IsDogSafe { get; set; }
        public bool IsCatSafe { get; set; }
        public bool IsOtherAnimalSafe { get; set; }
        public bool IsIndoorOnly { get; set; }
    }
}
