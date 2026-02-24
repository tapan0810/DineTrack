namespace DineTrack.Entities.Dtos
{
    public class MenuItemDto
    {
        public int MenuItemId { get; set; }
        public string FoodName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
