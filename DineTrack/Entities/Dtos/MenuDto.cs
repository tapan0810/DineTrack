namespace DineTrack.Entities.Dtos
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public DateTime MenuDate { get; set; }
        public string MealType { get; set; } = string.Empty;
        public List<MenuItemDto> Items { get; set; } = new();
    }
}
