using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace DineTrack.Entities.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string FoodName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string? ImageUrl { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        // Navigation
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
