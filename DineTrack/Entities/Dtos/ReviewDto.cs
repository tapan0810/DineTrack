namespace DineTrack.Entities.Dtos
{
    public class ReviewDto
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public string StudentName { get; set; } = string.Empty;
    }
}
