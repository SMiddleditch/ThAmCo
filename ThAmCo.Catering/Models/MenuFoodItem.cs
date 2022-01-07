using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Models
{
    public class MenuFoodItem
    {
        public MenuFoodItem()
        {
        }

        [Required]
        public int MenuId { get; set; }
        public int FoodItemId { get; set; }

        public Menu Menu { get; set; }
        public FoodItem foodItem { get; set; }
    }
}