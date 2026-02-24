namespace DineTrack.Entities.Models
{
    public class Menu
    {
        public Guid MenuId { get; set; }
        public DateTime MenuDate { get; set; }
        public string MealType { get; set; } = string.Empty;

        public Guid MessId { get; set; }
        public Mess Mess { get; set; } = null!;

        public Guid CreatedBy { get; set; }
        public User CreatedByUser { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        // Navigation
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
