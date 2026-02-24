namespace DineTrack.Entities.Models
{
    public class Mess
    {
        public int MessId { get; set; }
        public string MessName { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public int HostelId { get; set; }
        public Hostel Hostel { get; set; } = null!;

        public int ManagedByUserId { get; set; }
        public User ManagedByUser { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        // Navigation
        public ICollection<Menu> Menus { get; set; } = new List<Menu>();
        public ICollection<Complaints> Complaints { get; set; } = new List<Complaints>();
    }
}
