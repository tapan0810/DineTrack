using System.ComponentModel.DataAnnotations;

namespace DineTrack.Entities.Models
{
    public class Complaints
    {
        [Key]
        public int ComplaintId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Open";
        public string? ResponseMessage { get; set; }

        public int MessId { get; set; }
        public Mess Mess { get; set; } = null!;

        public int StudentId { get; set; }
        public User Student { get; set; } = null!;

        public int? ResolvedBy { get; set; }
        public User? ResolvedByUser { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}
