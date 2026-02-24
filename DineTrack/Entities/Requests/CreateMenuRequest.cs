namespace DineTrack.Entities.Requests
{
    public class CreateMenuRequest
    {
        public DateTime MenuDate { get; set; }
        public string MealType { get; set; } = string.Empty;
        public int MessId { get; set; }
    }
}
