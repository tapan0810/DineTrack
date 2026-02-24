namespace DineTrack.Entities.Models
{
    public class Complaints
    {
        public Guid ComplaintId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Open";
        public string? ResponseMessage { get; set; }

        public Guid MessId { get; set; }
        public Mess Mess { get; set; } = null!;

        public Guid StudentId { get; set; }
        public User Student { get; set; } = null!;

        public Guid? ResolvedBy { get; set; }
        public User? ResolvedByUser { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}
