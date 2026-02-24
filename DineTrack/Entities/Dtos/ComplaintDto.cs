namespace DineTrack.Entities.Dtos
{
    public class ComplaintDto
    {
        public int ComplaintId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? ResponseMessage { get; set; }
    }
}
