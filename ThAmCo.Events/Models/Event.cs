using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class Event    
    {
        public Event()
        {
        }
        public Event(int EvId, string ETy, string ETi, DateTime DT)
        {
            EventId = EvId;
            EventTitle = ETi;
            EventType = ETy;
            DateTime = DT;
        }

        public int EventId { get; set; }
        [Required]
        public string EventTitle { get; set; }
        public string EventType { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public ICollection<GuestBooking> GuestBooking { get; set; }
        public ICollection<Staffing> Staffing { get; set; }
    }
}
