using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Models
{
    public class FoodBooking
    {
        public FoodBooking()
        {
        }
        [Required]
        public int FoodBookingId { get; set; }
        public int MenuId { get; set; }
        public int ClientReference { get; set; }
        public int NumberOfGuest { get; set; }

        public Menu Menu { get; set; }
    }
}