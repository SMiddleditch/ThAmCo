using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class GuestBooking
    {
        public GuestBooking()
        {
        }
        public GuestBooking(int CusId, int EvId)
        {
            CustomerId = CusId;
            EventId = EvId;
        }

        [Required]
        public int CustomerId { get; set; }
        public int EventId { get; set; }

        public Customer Customer { get; set; }
        public Event Event { get; set; }
    }
}
