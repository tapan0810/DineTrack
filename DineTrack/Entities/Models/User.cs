using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace DineTrack.Entities.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public int RoleId { get; set; }

        //User: Belongs to one Role
        public Role Role { get; set; } = null!;

        public Guid HostelId { get; set; }

        //Belongs to one Hostel
        public Hostel Hostel { get; set; } = null!;

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Complaints> Complaints { get; set; } = new List<Complaints>();
    }
}
