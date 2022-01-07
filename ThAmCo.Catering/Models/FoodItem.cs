using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Models
{
    public class FoodItem
    {    
        public FoodItem()
        {
        }
        
        public int FoodItemId { get; set; }

        [Required]
        public string Description { get; set; }
        public float UnitPrice { get; set; }

        public ICollection<MenuFoodItem> menuFoodItem { get; set; }
    }
}