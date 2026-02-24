namespace DineTrack.Entities.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;

        public int StudentId { get; set; }
        public User Student { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}
