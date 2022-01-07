using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class Staffing
    {
        public Staffing()
        {
        }
        public Staffing(int EvId, int StfId)
        {
            EventId = EvId;
            StaffId = StfId;
        }

        [Required]
        public int EventId { get; set; }
        public int StaffId { get; set; }

        public Event Event { get; set; }
        public Staff Staff { get; set; }
    }
}
