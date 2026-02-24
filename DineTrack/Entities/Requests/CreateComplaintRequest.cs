namespace DineTrack.Entities.Requests
{
    public class CreateComplaintRequest
    {
        public string Description { get; set; } = string.Empty;
        public int MessId { get; set; }
    }
}
