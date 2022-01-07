using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Models
{
    public class Menu
    {
        public Menu()
        {
        }
        
        public int MenuId { get; set; }

        [Required]
        public string MenuName { get; set; }

        public ICollection<MenuFoodItem> menuFoodItem { get; set; }
    }
}