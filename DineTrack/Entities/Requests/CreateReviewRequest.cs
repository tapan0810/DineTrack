namespace DineTrack.Entities.Requests
{
    public class CreateReviewRequest
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public Guid MenuItemId { get; set; }
    }
}
