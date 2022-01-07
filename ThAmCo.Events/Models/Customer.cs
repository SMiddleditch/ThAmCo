using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class Customer
    {
        public Customer()
        {
        }
        public Customer(int CustId, string EM, string FN, string LN, bool Atten)
        {
            CustomerId = CustId;
            Email = EM;
            FirstName = FN;
            LastName = LN;
            Attendance = Atten;
        }

        [Required]
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Attendance { get; set; }

        public ICollection<GuestBooking> GuestBooking { get; set; }
    }
}
