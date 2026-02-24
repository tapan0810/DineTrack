namespace DineTrack.Entities.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

        public Guid MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;

        public Guid StudentId { get; set; }
        public User Student { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}
