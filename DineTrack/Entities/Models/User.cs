using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Text.Json.Serialization;

namespace DineTrack.Entities.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public int RoleId { get; set; }

        [JsonIgnore]
        public Role Role { get; set; } = null!;

        public int HostelId { get; set; }

        [JsonIgnore]
        public Hostel Hostel { get; set; } = null!;

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        [JsonIgnore]
        public ICollection<Complaints> Complaints { get; set; } = new List<Complaints>();
    }
}
